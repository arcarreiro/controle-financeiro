namespace ControleFinanceiro.Core.Interfaces
{
    public interface INotificacaoService
    {
        Task SendNotificacaoAsync(string mensagem, string usuarioId);
        Task CreateNotificacaoAsync(string mensagem, string usuarioId);
    }
}
