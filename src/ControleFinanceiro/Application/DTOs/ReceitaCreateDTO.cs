namespace ControleFinanceiro.Application.DTOs
{
    public class ReceitaCreateDTO
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Fonte { get; set; }
        public int idUsuario { get; set; }

        public ReceitaCreateDTO (string descricao, decimal valor, DateTime data, string fonte)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Fonte = fonte;
        }

        public ReceitaCreateDTO() { }
    }
}
