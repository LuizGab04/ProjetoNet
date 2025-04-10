using Dapper;
using ProjetoNet.Model;
using ProjetoNet.Repositories.Interfaces;
using BCrypt.Net;

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
            Console.WriteLine("Inserindo usuário no banco...");
            string senhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.senha_usuario);

            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"INSERT INTO Usuario(nome_usuario, email_usuario, senha_usuario) VALUES (@nome_usuario, @email_usuario, @senha_usuario); ";
            return await conexao.ExecuteScalarAsync<int>(sql, new 
            { 
                usuario.nome_usuario,
                usuario.email_usuario,
                senha_usuario = senhaHash

            });
        }

        public async Task<bool> EmailExiste(string? email_usuario)
        {
            if (string.IsNullOrWhiteSpace(email_usuario))
            {
                throw new ArgumentException("O e-mail do usuário não pode ser nulo ou vazio.", nameof(email_usuario));
            }
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"SELECT COUNT(*) FROM usuario WHERE email_usuario = '{email_usuario}'; ";
            int count = await conexao.ExecuteScalarAsync<int>(sql, new { email_usuario });
            return count > 0;
        }
        public async Task<Usuario?> GetUsuarioPorEmail(string? email_usuario)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"SELECT * FROM usuario WHERE email_usuario = @email_usuario; ";
            return await conexao.QueryFirstOrDefaultAsync<Usuario>(sql, new { email_usuario });
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
