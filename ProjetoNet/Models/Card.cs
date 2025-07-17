namespace ProjetoNet.Models
{
    public class Card
    {
        public int id_card { get; set; }
        public string? nome_card { get; set; } = "";
        public string? descricao { get; set; } = "";
        public int sprint_responsavel { get; set; }
        public int coluna_responsavel { get; set; }
    }
}
