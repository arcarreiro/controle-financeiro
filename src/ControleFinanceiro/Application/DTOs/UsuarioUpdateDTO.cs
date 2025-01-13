namespace ControleFinanceiro.Application.DTOs
{
    public class UsuarioUpdateDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UsuarioUpdateDTO (string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public UsuarioUpdateDTO() { }
    }
}
