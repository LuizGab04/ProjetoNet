using ProjetoNet.Models;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface ICard
    {
        Task<int> AdicionarCards(Card card);
        Task<IEnumerable<Card>> MostrarCards(int sprint_responsavel);
    }
}
