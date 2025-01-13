using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IReceitaRepository
    {
        Task<Receita?> GetReceitaByIdAsync(int id);
        Task<IEnumerable<Receita?>> GetAllReceitasAsync();
        Task<IEnumerable<Receita>> GetByMonthAsync(int ano, int mes, int usuarioId);
        Task<Receita> AddAsync(Receita receita);
        Task<Receita?> UpdateAsync(Receita receita);
        Task<bool> DeleteAsync(int id);
    }
}
