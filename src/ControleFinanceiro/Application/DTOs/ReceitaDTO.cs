using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Application.DTOs
{
    public class ReceitaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Fonte { get; set; }

        public ReceitaDTO (int id, string descricao, decimal valor, DateTime data, string fonte)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Fonte = fonte;
        }

        public ReceitaDTO() { }
    }
}
