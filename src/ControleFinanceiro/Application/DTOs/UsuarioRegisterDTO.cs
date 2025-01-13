namespace ControleFinanceiro.Application.DTOs
{
    public class UsuarioRegisterDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha {  get; set; } = string.Empty;

        public UsuarioRegisterDTO() { }

        public UsuarioRegisterDTO(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
