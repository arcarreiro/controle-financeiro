namespace ControleFinanceiro.Application.DTOs
{
    public class DespesaCreateDTO
    {
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public int idUsuario { get; set; }

        public DespesaCreateDTO (string descricao, decimal valor, DateTime data, string tipo)
        {
            Descricao = descricao;
            Valor = valor;
            Data = data;
            Tipo = tipo;
        }

        public DespesaCreateDTO() { }
    }
}
