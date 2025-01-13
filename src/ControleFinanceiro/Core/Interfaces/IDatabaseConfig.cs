using System.Data;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface IDatabaseConfig
    {
        IDbConnection GetConnection();
    }
}
