using ProjetoNet.Models;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface ICard
    {
        Task<int> CriarCard(Card card);
    }
}
