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

public class AuthService : IAuthService
{
    private readonly JwtConfig _jwtConfig;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IOptions<JwtConfig> jwtConfig, IUsuarioRepository usuarioRepository)
    {
        _jwtConfig = jwtConfig.Value;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AuthResultDTO> GenerateToken(string email)
    {
        var usuario = await _usuarioRepository.GetByEmail(email);
        if (usuario == null)
            throw new UnauthorizedAccessException("Usuário não encontrado.");


        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(ClaimTypes.Email, usuario.Email.Endereco),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(), ClaimValueTypes.DateTime)

        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtConfig.Issuer,
            audience: null,
            claims: claims,
            expires: DateTime.Now.AddDays(_jwtConfig.ExpireDays),
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        
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