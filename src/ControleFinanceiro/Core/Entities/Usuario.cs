using ControleFinanceiro.Core.ValueObjects;

namespace ControleFinanceiro.Core.Entities
{
    public class Usuario
    {

        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public Email Email { get; set; }
        public string SenhaHash { get; set; } = string.Empty;
        public decimal MetaFinanceira {  get; set; }

        public Usuario(string nome, string email, string senhaHash)
        {
            Nome = nome;
            Email = new Email(email);
            SenhaHash = senhaHash;
        }
        
        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
        }

        public Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = new Email(email) ?? throw new ArgumentNullException(nameof(email), "Email não pode ser nulo.");
        }
    }
        
  
}
