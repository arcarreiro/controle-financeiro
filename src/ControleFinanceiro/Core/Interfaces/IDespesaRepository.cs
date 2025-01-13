using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IDespesaRepository
    {
        Task<Despesa?> GetDespesaByIdAsync(int id);
        Task<IEnumerable<Despesa?>> GetAllDespesasAsync();
        Task<IEnumerable<Despesa>> GetByMonthAsync(int ano, int mes, int usuarioId);
        Task<Despesa> AddAsync(Despesa despesa);
        Task<Despesa?> UpdateAsync(Despesa despesa);
        Task<bool> DeleteAsync(int id);
    }
}
