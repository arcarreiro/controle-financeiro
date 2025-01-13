using ControleFinanceiro.Core.Enums;

namespace ControleFinanceiro.Core.Entities
{
    public class Despesa : TransacaoBase
    {
        public TipoDespesa Tipo { get; set; }

        public Despesa( int id, string descricao, decimal valor, DateTime data, TipoDespesa tipo, Usuario usuario)
            : base(descricao, valor, data, usuario)
        {
            Tipo = tipo;
        }

        public Despesa()
        {
            
        }

        public Despesa(string descricao, decimal valor, DateTime data, TipoDespesa tipo, Usuario usuario)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Tipo = tipo;
            Usuario = usuario;
        }
    }
}
