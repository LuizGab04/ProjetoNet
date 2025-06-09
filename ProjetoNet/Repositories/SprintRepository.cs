using System.Data;
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
            // Remova a chamada para OpenAsync, pois IDbConnection não suporta isso  
            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open(); // Use Open() em vez de OpenAsync()  
            }
            using var transacao = conexao.BeginTransaction();
            try
            {
                // Primeiro exclui os cards vinculados à sprint  
                string excluirCards = "DELETE FROM card WHERE sprint_responsavel = @id_sprint;";
                await conexao.ExecuteAsync(excluirCards, new { id_sprint }, transaction: transacao);

                // Depois exclui a sprint  
                string excluirSprint = "DELETE FROM sprint WHERE id_sprint = @id_sprint;";
                await conexao.ExecuteAsync(excluirSprint, new { id_sprint }, transaction: transacao);

                transacao.Commit();
                return 1; // sucesso  
            }
            catch
            {
                transacao.Rollback();
                return 0; // erro  
            }
        }
    }
}
