using ProjetoNet.Model;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface IUsuario
    {
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<int> AdicionarUsuario(Usuario usuario);
    }
}
