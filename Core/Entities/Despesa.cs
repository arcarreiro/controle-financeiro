using ControleFinanceiro.Core.Enums;

namespace ControleFinanceiro.Core.Entities
{
    public class Despesa : TransacaoBase
    {
        public required TipoDespesa Categoria { get; set; }

        public Despesa( int id, string descricao, decimal valor, DateTime data, TipoDespesa categoria, Usuario usuario)
            : base(descricao, valor, data, usuario)
        {
            Categoria = categoria;
        }

        public Despesa()
        {
            
        }
    }
}
