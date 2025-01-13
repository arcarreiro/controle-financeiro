using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IUsuarioRepository
    {

        Task<Usuario?> GetByIdAsync(int id);
        Task<IEnumerable<Usuario?>> GetAllAsync();
        Task<Usuario> AddAsync(UsuarioRegisterDTO usuario);
        Task<Usuario?> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> GetByEmail(string email);
    }
}
