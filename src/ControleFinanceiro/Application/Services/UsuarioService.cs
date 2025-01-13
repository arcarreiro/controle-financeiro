using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.Utils;
using ControleFinanceiro.Core.ValueObjects;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ControleFinanceiro.Application.Services
{
    public class UsuarioService : IUsuarioService
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
            return new UsuarioDTO(usuario.Id, usuario.Nome, usuario.Email.Endereco);
        }

        public async Task<List<UsuarioDTO>> GetAllUsuariosAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return usuarios
        .Select(u => u != null ? new UsuarioDTO(u.Id, u.Nome, u.Email.Endereco) : null)
        .Where(u => u != null)
        .ToList()!;
        }

        public async Task<UsuarioDTO> AddUsuarioAsync(UsuarioRegisterDTO usuarioRegisterDto)
        {
            if (string.IsNullOrWhiteSpace(usuarioRegisterDto.Email))
                throw new ArgumentException("O e-mail não pode ser nulo ou vazio.");

            var senhaHash = SenhaHasher.HashPassword(usuarioRegisterDto.Senha);
            usuarioRegisterDto.Senha = senhaHash;
            var novoUsuario = await _usuarioRepository.AddAsync(usuarioRegisterDto);
            return new UsuarioDTO(novoUsuario.Id, novoUsuario.Nome, novoUsuario.Email.Endereco);
        }

        public async Task<UsuarioDTO?> UpdateUsuarioAsync(int id, UsuarioUpdateDTO usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.GetByIdAsync(id);
            if (usuarioExistente == null) 
                return null;

            if (!string.IsNullOrEmpty(usuarioDto.Nome))
            {
                usuarioExistente.Nome = usuarioDto.Nome;
            }

            if (!string.IsNullOrEmpty(usuarioDto.Email))
            {
                usuarioExistente.Email = new Email(usuarioDto.Email);
            }

            await _usuarioRepository.UpdateAsync(usuarioExistente);
           
            return new UsuarioDTO(usuarioExistente.Id, usuarioExistente.Nome, usuarioExistente.Email.Endereco);
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
