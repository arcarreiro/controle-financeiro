namespace ControleFinanceiro.Infrastructure.Configurations
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpireDays { get; set; }
    }
}