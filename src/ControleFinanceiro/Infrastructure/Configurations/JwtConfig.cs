namespace ControleFinanceiro.Infrastructure.Configurations
{
    public class JwtConfig
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int ExpireDays { get; set; }
    }
}