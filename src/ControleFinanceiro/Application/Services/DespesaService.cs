using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Enums;
using ControleFinanceiro.Core.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DespesaService(IDespesaRepository despesaRepository, IUsuarioRepository usuarioRepository)
        {
            _despesaRepository = despesaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<DespesaDTO?> GetDespesaByIdAsync(int id)
        {
            var despesa = await _despesaRepository.GetDespesaByIdAsync(id);
            if (despesa == null) return null;

            return new DespesaDTO(despesa.Id, despesa.Descricao, despesa.Valor, despesa.Data, despesa.Tipo.ToString());
        }

        public async Task<IEnumerable<DespesaDTO>> GetDespesasByMonthAsync(int ano, int mes, int usuarioId)
        {
            var despesas = await _despesaRepository.GetByMonthAsync(ano, mes, usuarioId);
            return despesas.Select(d => new DespesaDTO(d.Id, d.Descricao, d.Valor, d.Data, d.Tipo.ToString()));
        }

        public async Task<DespesaDTO> AddDespesaAsync(DespesaCreateDTO despesaDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(despesaDto.idUsuario);
            if (usuario == null)
                throw new DirectoryNotFoundException("Usuário não encontrado.");

            var tipoDespesa = despesaDto.Tipo.ToTipoDespesa();

            var novaDespesa = new Despesa(despesaDto.Descricao, (decimal)despesaDto.Valor, (DateTime)despesaDto.Data, tipoDespesa, usuario);
            var result = await _despesaRepository.AddAsync(novaDespesa);
            return new DespesaDTO(result.Id, novaDespesa.Descricao, novaDespesa.Valor, novaDespesa.Data, novaDespesa.Tipo.ToString());
        }

        public async Task<DespesaDTO?> UpdateDespesaAsync(int id, DespesaUpdateDTO despesaUpdateDto)
        {
            var despesaExistente = await _despesaRepository.GetDespesaByIdAsync(id);
            if (despesaExistente == null) return null;

            if (!string.IsNullOrWhiteSpace(despesaUpdateDto.Descricao))
                despesaExistente.Descricao = despesaUpdateDto.Descricao;

            if (despesaUpdateDto.Valor != null)
                despesaExistente.Valor = (decimal)despesaUpdateDto.Valor;

            if (despesaUpdateDto.Data != null)
                despesaExistente.Data = (DateTime)despesaUpdateDto.Data;

            if (!string.IsNullOrWhiteSpace(despesaUpdateDto.Tipo))
            {
                var tipoDespesa = despesaUpdateDto.Tipo.ToTipoDespesa();
                despesaExistente.Tipo = tipoDespesa;
            }

            await _despesaRepository.UpdateAsync(despesaExistente);
            return new DespesaDTO(despesaExistente.Id, despesaExistente.Descricao, despesaExistente.Valor, despesaExistente.Data, despesaExistente.Tipo.ToString());
        }

        public async Task<bool> DeleteDespesaAsync(int id)
        {
            var despesaExistente = await _despesaRepository.GetDespesaByIdAsync(id);
            if (despesaExistente == null) return false;

            await _despesaRepository.DeleteAsync(id);
            return true;
        }

        public decimal SomatorioMensal(IEnumerable<DespesaDTO> despesas)
        {
            return despesas.Sum(d => d.Valor);
        }
    }
}
