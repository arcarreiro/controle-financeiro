using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Infrastructure.Configurations;
using Dapper;

namespace ControleFinanceiro.Infrastructure.Data
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly IDatabaseConfig _databaseConfig;

        public NotificacaoRepository(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<Notificacao?> GetNotificacaoByIdAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM notificacoes WHERE id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Notificacao>(query, new { Id = id });
        }

        public async Task<IEnumerable<Notificacao?>> GetAllNotificacoesAsync()
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "SELECT * FROM notificacoes";
            return await connection.QueryAsync<Notificacao>(query);
        }

        public async Task<Notificacao> AddAsync(Notificacao notificacao)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "INSERT INTO notificacoes (mensagem, data) VALUES (@Mensagem, @Data) RETURNING id";
            var id = await connection.ExecuteScalarAsync<int?>(query, notificacao);
            if (!id.HasValue)
            {
                throw new Exception("Falha ao gerar o ID para a notificação");
            }
            notificacao.Id = id.Value;
            return notificacao;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "DELETE FROM notificacoes WHERE id = @Id";
            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
