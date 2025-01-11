using ControleFinanceiro.Core.ValueObjects;

namespace ControleFinanceiro.Core.Entities
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public required Email Email { get; set; }
        public required string SenhaHash { get; set; } = string.Empty;
        public decimal MetaFinanceira {  get; set; }

        public Usuario(string nome, Email email, string senhaHash)
        {
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
        }

        public Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = new Email(email) ?? throw new ArgumentNullException(nameof(email), "Email não pode ser nulo.");
        }
    }
        
  
}
