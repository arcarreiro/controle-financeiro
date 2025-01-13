using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;

namespace ControleFinanceiro.Application.Services
{
    public class ReceitaService : IReceitaService
    {
        private readonly IReceitaRepository _receitaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ReceitaService(IReceitaRepository receitaRepository, IUsuarioRepository usuarioRepository)
        {
            _receitaRepository = receitaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ReceitaDTO?> GetReceitaByIdAsync(int id)
        {
            var receita = await _receitaRepository.GetReceitaByIdAsync(id);
            if (receita == null) return null;

            return new ReceitaDTO(receita.Id, receita.Descricao, receita.Valor, receita.Data, receita.Fonte);
        }

        public async Task<IEnumerable<ReceitaDTO>> GetReceitasByMonthAsync(int ano, int mes, int usuarioId)
        {
            var receitas = await _receitaRepository.GetByMonthAsync(ano, mes, usuarioId);
            return receitas.Select(r => new ReceitaDTO(r.Id, r.Descricao, r.Valor, r.Data, r.Fonte));
        }

        public async Task<ReceitaDTO> AddReceitaAsync(ReceitaCreateDTO receitaDto)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(receitaDto.idUsuario);
            if (usuario == null)
                throw new DirectoryNotFoundException("Usuário não encontrado.");

            var novaReceita = new Receita(receitaDto.Descricao, (decimal)receitaDto.Valor, (DateTime)receitaDto.Data, receitaDto.Fonte, usuario);
            var result = await _receitaRepository.AddAsync(novaReceita);
            return new ReceitaDTO(result.Id, novaReceita.Descricao, novaReceita.Valor, novaReceita.Data, novaReceita.Fonte);
        }

        public async Task<ReceitaDTO?> UpdateReceitaAsync(int id, ReceitaUpdateDTO receitaUpdateDto)
        {
            var receitaExistente = await _receitaRepository.GetReceitaByIdAsync(id);
            if (receitaExistente == null) return null;

            // Atualização condicional
            if (!string.IsNullOrWhiteSpace(receitaUpdateDto.Descricao))
                receitaExistente.Descricao = receitaUpdateDto.Descricao;

            if (receitaUpdateDto.Valor != null)
                receitaExistente.Valor = (decimal)receitaUpdateDto.Valor;

            if (receitaUpdateDto.Data != null)
                receitaExistente.Data = (DateTime)receitaUpdateDto.Data;

            if (!string.IsNullOrWhiteSpace(receitaUpdateDto.Fonte))
                receitaExistente.Fonte = receitaUpdateDto.Fonte;

            await _receitaRepository.UpdateAsync(receitaExistente);
            return new ReceitaDTO(receitaExistente.Id, receitaExistente.Descricao, receitaExistente.Valor, receitaExistente.Data, receitaExistente.Fonte);
        }

        public async Task<bool> DeleteReceitaAsync(int id)
        {
            var receitaExistente = await _receitaRepository.GetReceitaByIdAsync(id);
            if (receitaExistente == null) return false;

            await _receitaRepository.DeleteAsync(id);
            return true;
        }

        public decimal SomatorioMensal(IEnumerable<ReceitaDTO> receitas)
        {
            return receitas.Sum(r => r.Valor);
        }
    }
}
