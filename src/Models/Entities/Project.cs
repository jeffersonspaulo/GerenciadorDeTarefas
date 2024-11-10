namespace TaskManager.Models.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public List<Task> Tarefas { get; set; }
    }
}
