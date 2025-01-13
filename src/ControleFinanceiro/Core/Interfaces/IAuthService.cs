namespace ControleFinanceiro.Core.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(string email);
        Task<bool> ValidateUserCredentials(string email, string senha);
    }
}