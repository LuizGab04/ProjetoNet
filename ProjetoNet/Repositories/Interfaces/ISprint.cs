using ProjetoNet.Models;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface ISprint
    {
        Task<int> AdicionarSprint(Sprint sprint);
        Task<IEnumerable<Sprint>> MostrarSprints();
        Task<int?> ExcluirSprint(int id_sprint);
    }
}
