namespace ControleFinanceiro.Core.Entities
{
    public abstract class TransacaoBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public Usuario Usuario { get; set; }

        protected TransacaoBase()
        {
            
        }

        protected TransacaoBase(string descricao, decimal valor, DateTime data, Usuario usuario)
        {
            Valor = valor;
            Data = data;
            Descricao = descricao;
            Usuario = usuario;
        }

    }
}
