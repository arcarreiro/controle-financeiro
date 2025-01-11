using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Infrastructure.Configurations;
using Dapper;

namespace ControleFinanceiro.Infrastructure.Data
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly IDatabaseConfig _databaseConfig;

        public ReceitaRepository(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Receita?> GetReceitaByIdAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM receitas WHERE id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Receita>(query, new { Id = id });
        }

        public async Task<IEnumerable<Receita?>> GetAllReceitasAsync()
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM receitas";
            return await connection.QueryAsync<Receita>(query);
        }

        public async Task<Receita> AddAsync(Receita receita)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "INSERT INTO receitas (descricao, valor, data) VALUES (@Descricao, @Valor, @Data) RETURNING id";
            var id = await connection.ExecuteScalarAsync<int?>(query, receita);
            
            if (!id.HasValue)
            {
                throw new Exception("Falha ao gerar o ID para a Receita");
            }

            receita.Id = (int)id;
            return receita;
        }

        public async Task<Receita?> UpdateAsync(Receita receita)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "UPDATE receitas SET descricao = @Descricao, valor = @Valor, data = @Data WHERE id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, receita);
            return rowsAffected > 0 ? receita : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "DELETE FROM receitas WHERE id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
