using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Enums;

namespace ControleFinanceiro.Application.DTOs
{
    public class DespesaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }

        public DespesaDTO(int id, string descricao, decimal valor, DateTime data, string tipo)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Tipo = tipo;
        }

        public DespesaDTO() { }
    }
}
