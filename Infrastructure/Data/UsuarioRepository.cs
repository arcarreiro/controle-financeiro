using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Infrastructure.Configurations;
using Dapper;

namespace ControleFinanceiro.Infrastructure.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDatabaseConfig _databaseConfig;

        public UsuarioRepository(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
                var query = "SELECT * FROM usuarios WHERE id = @Id";
                var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });
                return usuario;
        }
        public async Task<IEnumerable<Usuario?>> GetAllAsync()
        {
            using var connection = _databaseConfig.GetConnection();
                var query = "SELECT * FROM usuarios";
                var usuarios = await connection.QueryAsync<Usuario>(query);
                return usuarios;
            
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            using var connection = _databaseConfig.GetConnection();
                var query = "INSERT INTO usuarios (nome, email, senha) VALUES (@Nome, @Email, @Senha) RETURNING id";
                var id = await connection.ExecuteScalarAsync<int?>(query, usuario);

            if (!id.HasValue)
            {
                throw new Exception("Falha ao gerar o ID para o usuário");
            }

                usuario.Id = (int)id;
                return usuario;
        }
        public async Task<Usuario?> UpdateAsync(Usuario usuario)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "UPDATE usuarios SET nome = @Nome, email = @Email WHERE id = @Id RETURNING id";

            var id = await connection.ExecuteScalarAsync<int?>(query, usuario);

            if (!id.HasValue)
            {
                return null;
            }

            usuario.Id = id.Value;
            return usuario;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "DELETE FROM usuarios WHERE id = @Id";

            var rowsAffected = await connection.ExecuteAsync(query, new { Id = id });

            return rowsAffected > 0;
        }



    }
}
