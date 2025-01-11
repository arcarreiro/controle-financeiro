namespace ControleFinanceiro.Core.Entities
{
    public class Notificacao
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
            Data = DateTime.UtcNow;
        }
    }
}
