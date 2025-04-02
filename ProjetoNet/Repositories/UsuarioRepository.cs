using Dapper;
using ProjetoNet.Model;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Repositories
{
    public class UsuarioRepository : IUsuario
    {

        private readonly DbConexaoFactory _dbConexaoFactory;

       

        public UsuarioRepository(DbConexaoFactory dbConexaoFactory) => _dbConexaoFactory = dbConexaoFactory;

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            return await conexao.QueryAsync<Usuario>("SELECT * FROM Usuario");
        }

        public async Task<Usuario?> GetUsuarioById(int id)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();

            return await conexao.QueryFirstOrDefaultAsync<Usuario>($"SELECT * FROM Usuario WHERE id_usuario = {id}");

        }

        public async Task<int> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                Console.WriteLine("Inserindo usuário no banco...");
                using var conexao = _dbConexaoFactory.CreateConnection();
                string sql = $"INSERT INTO Usuario(nome_usuario, email_usuario, senha_usuario) VALUES (@nome_usuario, @email_usuario, @senha_usuario); ";
                return await conexao.ExecuteScalarAsync<int>(sql, usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao inserir no banco: {ex.Message}");
                throw;  // Re-lance a exceção para ser capturada no controlador
            }
        }

        public async Task<bool> EmailExiste(string? email_usuario)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"SELECT COUNT(*) FROM usuarios WHERE email_usuario = @email_usuario";
            int count = await conexao.ExecuteScalarAsync<int>(sql, email_usuario);
            return count > 0;
        }

        Task<IEnumerable<Usuario>> IUsuario.ListarUsuarios()
        {
            throw new NotImplementedException();
        }

        Task<Usuario> IUsuario.GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
