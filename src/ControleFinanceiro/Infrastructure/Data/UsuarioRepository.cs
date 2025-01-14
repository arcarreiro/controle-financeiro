using ControleFinanceiro.Application.DTOs;
using ControleFinanceiro.Core.Entities;
using ControleFinanceiro.Core.Interfaces;
using ControleFinanceiro.Core.ValueObjects;
using ControleFinanceiro.Infrastructure.Configurations;
using Dapper;
using System.Data;

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
                return await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Id = id });

        }
        public async Task<IEnumerable<Usuario?>> GetAllAsync()
        {
            using var connection = _databaseConfig.GetConnection();
                var query = "SELECT * FROM usuarios";
                var usuarios = await connection.QueryAsync<Usuario>(query);
                return usuarios;
            
        }

        public async Task<Usuario> AddAsync(UsuarioRegisterDTO usuario)
        {
            using var connection = _databaseConfig.GetConnection();
            var query = "INSERT INTO usuarios (nome, email, senha_hash) VALUES (@Nome, @Email, @Senha) RETURNING id";
           
            var id = await connection.ExecuteScalarAsync<int>(query, usuario);
            var novoUsuario = new Usuario(id, usuario.Nome, usuario.Email);


            return novoUsuario;           

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

        public async Task<Usuario?> GetByEmail(string email)
        {
            const string query = "SELECT * FROM Usuarios WHERE Email = @Email";

            using var connection = _databaseConfig.GetConnection();
            
            var usuario = await connection.QueryFirstOrDefaultAsync<Usuario>(query, new { Email = email });
            Console.WriteLine("Usuario recuperado do banco: " + usuario.Email + " hash: " + usuario.SenhaHash);
            return usuario;
            
        }

    }
}
