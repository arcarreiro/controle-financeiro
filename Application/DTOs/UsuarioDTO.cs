using ControleFinanceiro.Core.ValueObjects;

namespace ControleFinanceiro.Application.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public UsuarioDTO() { }

        public UsuarioDTO(int id, string nome, Email email)
        {
            Id = id;
            Nome = nome;
            Email = email.Endereco;
        }
    }
}
