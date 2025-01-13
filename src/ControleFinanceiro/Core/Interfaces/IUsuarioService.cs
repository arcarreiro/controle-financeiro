using ControleFinanceiro.Application.DTOs;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> AddUsuarioAsync(UsuarioRegisterDTO usuarioDto);
        Task<bool> DeleteUsuarioAsync(int id);
        Task<List<UsuarioDTO>> GetAllUsuariosAsync();
        Task<UsuarioDTO?> GetUsuarioByIdAsync(int id);
        Task<UsuarioDTO?> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioDto);
    }
}