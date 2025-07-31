namespace ProjetoNet.Models
{
    public class Sprint
    {
        public int id_sprint { get; set; }
        public string? nome_sprint { get; set; } = "";
        public DateTime data_inicio { get; set;}
        public DateTime data_fim { get; set; }

    }
}
