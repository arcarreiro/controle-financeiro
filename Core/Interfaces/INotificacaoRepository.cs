using ControleFinanceiro.Core.Entities;

namespace ControleFinanceiro.Core.Interfaces
{
    public interface INotificacaoRepository
    {
        Task<Notificacao?> GetNotificacaoByIdAsync(int id);
        Task<IEnumerable<Notificacao?>> GetAllNotificacoesAsync();
        Task<Notificacao> AddAsync(Notificacao notificacao);
        Task<bool> DeleteAsync(int id);
    }
}
