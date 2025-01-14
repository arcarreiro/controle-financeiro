using ControleFinanceiro.Application.DTOs;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResultDTO> GenerateToken(string email);
        Task<bool> ValidateUserCredentials(string email, string senha);
    }
}