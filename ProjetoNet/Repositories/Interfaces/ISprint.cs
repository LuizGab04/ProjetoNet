using ProjetoNet.Models;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface ISprint
    {
        Task<int> AdicionarSprint(Sprint sprint);
        Task<IEnumerable<Sprint>> MostrarSprints();
    }
}
