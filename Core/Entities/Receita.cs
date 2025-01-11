using ControleFinanceiro.Core.Enums;

namespace ControleFinanceiro.Core.Entities
{
    public class Receita : TransacaoBase
    {
        public string Fonte { get; set; } = string.Empty;

        public Receita(string descricao, decimal valor, DateTime data, string fonte, Usuario usuario)
            : base(descricao, valor, data, usuario)
        {
            Fonte = fonte;
        }

        public Receita()
        {
            
        }
    }
}
