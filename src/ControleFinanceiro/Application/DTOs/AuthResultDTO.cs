namespace ControleFinanceiro.Application.DTOs
{
    public class AuthResultDTO
    {
        public string Token { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
