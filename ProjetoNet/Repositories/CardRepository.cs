using Dapper;
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
        public async Task AtualizarCard(Card card)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $@"UPDATE Card 
                   SET nome_card = '{card.nome_card}', 
                       sprint_responsavel = {card.sprint_responsavel}, 
                       coluna_responsavel = {card.coluna_responsavel}
                   WHERE id_card = {card.id_card};";

            await conexao.ExecuteAsync(sql, card);
        }
        public async Task<IEnumerable<Card>> MostrarCards(int id_sprint)
        {
            using var conexao = _dbConexaoFactory.CreateConnection();
            string sql = $"SELECT * FROM Card WHERE sprint_responsavel = {id_sprint};";

            return await conexao.QueryAsync<Card>(sql);
        }
    }
}
