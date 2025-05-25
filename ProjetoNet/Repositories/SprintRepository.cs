using Dapper;
using ProjetoNet.Models;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Repositories
{
    public class SprintRepository : ISprint
    {
        private readonly DbConexaoFactory _dbConexaoFactory;
        public SprintRepository(DbConexaoFactory dbConexaoFactory) => _dbConexaoFactory = dbConexaoFactory;

        public async Task<int> AdicionarSprint(Sprint sprint)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"INSERT INTO Sprint(nome_sprint) VALUES (@nome_sprint); ";
            return await conexao.ExecuteScalarAsync<int>(sql, new
            {
                sprint.nome_sprint
            });
        }

        public async Task<IEnumerable<Sprint>> MostrarSprints()
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"select * from sprint order by id_sprint desc;";

            return await conexao.QueryAsync<Sprint>(sql);
        }

        public async Task<int?> ExcluirSprint(int id_sprint)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"DELETE FROM sprint WHERE id_sprint = @id_sprint;";

            return await conexao.ExecuteAsync(sql, new { id_sprint });
        }

        
    }
}
