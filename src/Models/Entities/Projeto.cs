using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Models.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }

        public Usuario Usuario { get; set; }
        public List<Tarefa> Tarefas { get; set; }
    }
}
