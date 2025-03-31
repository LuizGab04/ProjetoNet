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
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = "INSERT INTO Usuarios(Nome, Email) VALUES(@Nome, @Email); SELECT LAST_INSERT_ID(); ";
            return await conexao.ExecuteScalarAsync<int>(sql, usuario);
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
