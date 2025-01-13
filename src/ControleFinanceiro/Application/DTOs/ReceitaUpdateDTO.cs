namespace ControleFinanceiro.Application.DTOs
{
    public class ReceitaUpdateDTO
    {
        public string? Descricao { get; set; } = string.Empty;
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public string? Fonte { get; set; }

        public ReceitaUpdateDTO (string descricao, decimal valor, DateTime data, string fonte)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Fonte = fonte;
        }

        public ReceitaUpdateDTO() { }
    }
}
