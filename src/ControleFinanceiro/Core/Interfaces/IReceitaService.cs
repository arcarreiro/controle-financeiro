using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IReceitaService
    {
        Task<ReceitaDTO> AddReceitaAsync(ReceitaCreateDTO receitaDto);
        Task<bool> DeleteReceitaAsync(int id);
        Task<ReceitaDTO?> GetReceitaByIdAsync(int id);
        Task<IEnumerable<ReceitaDTO>> GetReceitasByMonthAsync(int ano, int mes, int usuarioId);
        Task<ReceitaDTO?> UpdateReceitaAsync(int id, ReceitaUpdateDTO receitaUpdateDto);
        public decimal SomatorioMensal(IEnumerable<ReceitaDTO> receitas);
    }
}