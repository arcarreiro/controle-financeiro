using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Infrastructure.Configurations;
using Dapper;

namespace ControleFinanceiro.Infrastructure.Data
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly IDatabaseConfig _databaseConfig;

        public DespesaRepository(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Despesa?> GetDespesaByIdAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM despesas WHERE id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Despesa>(query, new { Id = id });
        }

        public async Task<IEnumerable<Despesa?>> GetAllDespesasAsync()
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM despesas";
            return await connection.QueryAsync<Despesa>(query);
        }

        public async Task<IEnumerable<Despesa>> GetByMonthAsync(int ano, int mes, int usuarioId)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = @"
            SELECT * FROM despesas 
            WHERE EXTRACT(YEAR FROM data) = @Ano 
            AND EXTRACT(MONTH FROM data) = @Mes
            AND id_usuario = @UsuarioId";

            var despesas = await connection.QueryAsync<Despesa>(query, new { Ano = ano, Mes = mes, UsuarioId = usuarioId });
            return despesas;
        }

        public async Task<Despesa> AddAsync(Despesa despesa)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "INSERT INTO despesas (descricao, valor, data, id_usuario, tipo) VALUES (@Descricao, @Valor, @Data, @UsuarioId, @Tipo) RETURNING id";
            var id = await connection.ExecuteScalarAsync<int?>(query, new
            {
                Descricao = despesa.Descricao,
                Valor = despesa.Valor,
                Data = despesa.Data,
                UsuarioId = despesa.Usuario.Id,
                Tipo = despesa.Tipo.ToString()
            });

            if (!id.HasValue)
            {
                throw new Exception("Falha ao gerar o ID para a Despesa");
            }

            despesa.Id = (int)id;
            return despesa;
        }

        public async Task<Despesa?> UpdateAsync(Despesa despesa)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "UPDATE despesas SET descricao = @Descricao, valor = @Valor, data = @Data, tipo = @Tipo WHERE id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new
            {
                Descricao = despesa.Descricao,
                Valor = despesa.Valor,
                Data = despesa.Data,
                Tipo = despesa.Tipo.ToString(),
                Id = despesa.Id
            });
            return rowsAffected > 0 ? despesa : null;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "DELETE FROM despesas WHERE id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
