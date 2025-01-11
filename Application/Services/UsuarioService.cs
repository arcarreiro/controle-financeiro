using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.Utils;
using ControleFinanceiro.Core.ValueObjects;

namespace ControleFinanceiro.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuarioDTO?> GetUsuarioByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return null;
            }
            return new UsuarioDTO(usuario.Id, usuario.Nome, usuario.Email);
        }

        public async Task<List<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios
        .Select(u => u != null ? new UsuarioDTO(u.Id, u.Nome, u.Email) : null)
        .Where(u => u != null)
        .ToList()!;
        }

        public async Task<UsuarioDTO> AddUsuarioAsync(UsuarioDTO usuarioDto, string senha)
        {
            if (string.IsNullOrWhiteSpace(usuarioDto.Email))
                throw new ArgumentException("O e-mail não pode ser nulo ou vazio.");

            var email = new Email(usuarioDto.Email);
            var senhaHash = SenhaHasher.HashPassword(senha);
            var usuario = new Usuario() { Nome = usuarioDto.Nome, Email = email, SenhaHash = senhaHash};
            var novoUsuario = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioDTO(novoUsuario.Id, novoUsuario.Nome, novoUsuario.Email);
        }

        public async Task<bool> UpdateUsuarioAsync(int id, UsuarioDTO usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null) return false;

            usuarioExistente.Nome = usuarioDto.Nome;
            usuarioExistente.Email = new Email(usuarioDto.Email);

            await _usuarioRepository.UpdateAsync(usuarioExistente);
            return true;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null) return false;

            await _usuarioRepository.DeleteAsync(id);
            return true;
        }
    }
}
