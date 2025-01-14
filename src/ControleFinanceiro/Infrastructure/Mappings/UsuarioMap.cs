using ControleFinanceiro.Core.Entities;
using Dapper.FluentMap.Mapping;

namespace ControleFinanceiro.Infrastructure.Mappings
{
    public class UsuarioMap : EntityMap<Usuario>
    {

        public UsuarioMap() 
        {
            Map(u => u.SenhaHash).ToColumn("senha_hash");
        }
    }
}
