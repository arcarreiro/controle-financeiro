namespace ControleFinanceiro.Core.Enums
{
    public enum TipoDespesa
    {
        Habitacao,
        ServicosEssenciais,
        Transporte,
        Entretenimento,
        Compras,
        Outros
    }
    public static class TipoDespesaExtensions
    {
        public static TipoDespesa ToTipoDespesa(this string tipo)
        {
            if (Enum.TryParse(tipo, true, out TipoDespesa tipoDespesa))
            {
                return tipoDespesa;
            }
            else
            {
                return TipoDespesa.Outros;
            }
        }
    }
}
