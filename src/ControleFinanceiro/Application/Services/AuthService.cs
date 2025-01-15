namespace ControleFinanceiro.Application.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ControleFinanceiro.Infrastructure.Configurations;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.Utils;
using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Infrastructure.Security;

public class AuthService : IAuthService
{
    private readonly JwtService _jwtService;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IUsuarioRepository usuarioRepository, JwtService jwtService)
    {
        _jwtService = jwtService;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AuthResultDTO> GenerateToken(string email)
    {
        var usuario = await _usuarioRepository.GetByEmail(email);
        if (usuario == null)
            throw new UnauthorizedAccessException("Usuário não encontrado.");

        var tokenString = _jwtService.GenerateToken(usuario);
        
        return new AuthResultDTO
        {
            Token = tokenString,
            UsuarioId = usuario.Id,
            Nome = usuario.Nome,
            Email = usuario.Email.Endereco
        };
    }

    public async Task<bool> ValidateUserCredentials(string email, string senha)
    {
        var usuario = await _usuarioRepository.GetByEmail(email);
        if (usuario == null)
            return false;

        bool senhaValida = SenhaHasher.VerifyPassword(senha, usuario.SenhaHash);

        return senhaValida;
    }
}