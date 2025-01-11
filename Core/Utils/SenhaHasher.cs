namespace ControleFinanceiro.Core.Utils;


public static class SenhaHasher
{
    public static string HashPassword(string senha)
    {
        return BCrypt.Net.BCrypt.HashPassword(senha);
    }

    public static bool VerifyPassword(string senha, string hashedSenha)
    {
        return BCrypt.Net.BCrypt.Verify(senha, hashedSenha);
    }
}

