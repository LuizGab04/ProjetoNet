using ProjetoNet.Model;

namespace ProjetoNet.Repositories.Interfaces
{
    public interface IUsuario
    {
        Task<int> AdicionarUsuario(Usuario usuario);
        Task<bool> EmailExiste(string email_usuario);
        Task<Usuario?> GetUsuarioPorEmail(String email_usuario);
        Task<byte[]?> ObterFotoPerfilAsync(string email);
        Task SalvarFotoPerfilAsync(string email_usuario, byte[] foto);
    }
}
