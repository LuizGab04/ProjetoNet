using System.Collections;
using Dapper;
using ProjetoNet.Models;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Repositories
{
    public class SprintRepository : ISprint
    {
        private readonly DbConexaoFactory _dbConexaoFactory;
        public SprintRepository(DbConexaoFactory dbConexaoFactory) => _dbConexaoFactory = dbConexaoFactory;
        private string? SQL;

        public async Task<int> AdicionarSprint(Sprint sprint)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"INSERT INTO Sprint(nome_sprint) VALUES (@nome_sprint); ";
            return await conexao.ExecuteScalarAsync<int>(sql, new
            {
                sprint.nome_sprint
            });
        }

        public async Task<IEnumerable<Sprint>> MostrarSprints() // Change return type to IEnumerable<Sprint>
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"select * from sprint order by id_sprint desc;";

            return await conexao.QueryAsync<Sprint>(sql); // Use QueryAsync<T> to return a collection of Sprint objects
        }

  
    }
}
