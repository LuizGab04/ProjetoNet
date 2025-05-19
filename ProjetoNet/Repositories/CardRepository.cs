using Dapper;
using ProjetoNet.Models;

namespace ProjetoNet.Repositories
{
    public class CardRepository
    {
        private readonly DbConexaoFactory _dbConexaoFactory;
        public CardRepository(DbConexaoFactory dbConexaoFactory) => _dbConexaoFactory = dbConexaoFactory;

        public async Task<int> CriarCard(Card card){
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"INSERT INTO card (nome_ card) VALUES (@nome_card);";
            return await conexao.ExecuteScalarAsync<int>(sql, new
            {
                card.nome_card
            });
        }
    }
}
