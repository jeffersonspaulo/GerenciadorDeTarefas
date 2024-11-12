using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.Models.Entities;
using Newtonsoft.Json;

namespace GerenciadorDeTarefas.API.Models.Entities
{
    public class TarefaHistorico
    {
        public int Id { get; set; }
        public int TarefaId { get; set; }
        public int ProjetoId { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public TarefaStatus TarefaStatus { get; set; }
        public Prioridade Prioridade { get; set; }

        public DateTime DataInclusao { get; set; }
        public string Comentario { get; set; }

        [JsonIgnore]
        public Tarefa Tarefa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
