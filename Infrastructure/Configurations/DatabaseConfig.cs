namespace ControleFinanceiro.Infrastructure.Configurations

{
    using Npgsql;
    using System.Data;
    using Microsoft.Extensions.Configuration;
    using ControleFinanceiro.Core.Interfaces;

    public class DatabaseConfig : IDatabaseConfig
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            return new NpgsqlConnection(connectionString);
        }
    }
}