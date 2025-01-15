using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Infrastructure.Configurations;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControleFinanceiro.Infrastructure.Security
{
    public class JwtService
    {
        public string GenerateToken (Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtConfig.Key);

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, usuario.Nome),
                new(ClaimTypes.Email, usuario.Email.Endereco),
                new(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken (tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
