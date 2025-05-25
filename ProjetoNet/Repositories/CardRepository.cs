using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ProjetoNet.Models;
using ProjetoNet.Repositories.Interfaces;

namespace ProjetoNet.Repositories
{
    public class CardRepository : ICard
    {
        private readonly DbConexaoFactory _dbConexaoFactory;
        public CardRepository(DbConexaoFactory dbConexaoFactory) => _dbConexaoFactory = dbConexaoFactory;

        public async Task<int> AdicionarCards(Card card)
        {
                using var conexao = _dbConexaoFactory.CreateConnection();
                string sql = $"INSERT INTO Card(nome_card, sprint_responsavel) VALUES ('{card.nome_card}', {card.sprint_responsavel});";

                return await conexao.ExecuteAsync(sql, new { card });
        }
    }
}
