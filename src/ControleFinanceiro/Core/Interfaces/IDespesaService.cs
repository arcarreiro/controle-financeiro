using ControleFinanceiro.Application.DTOs;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IDespesaService
    {
        Task<DespesaDTO> AddDespesaAsync(DespesaCreateDTO despesaDto);
        Task<bool> DeleteDespesaAsync(int id);
        Task<DespesaDTO?> GetDespesaByIdAsync(int id);
        Task<IEnumerable<DespesaDTO>> GetDespesasByMonthAsync(int ano, int mes, int usuarioId);
        decimal SomatorioMensal(IEnumerable<DespesaDTO> despesas);
        Task<DespesaDTO?> UpdateDespesaAsync(int id, DespesaUpdateDTO despesaUpdateDto);
    }
}