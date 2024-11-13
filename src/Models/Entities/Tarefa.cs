using GerenciadorDeTarefas.API.Models.Enums;
using Newtonsoft.Json;

namespace GerenciadorDeTarefas.API.Models.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public TarefaStatus TarefaStatus { get; set; }
        public Prioridade Prioridade { get; set; }

        [JsonIgnore]
        public Projeto Projeto { get; set; }

        [JsonIgnore]
        public List<TarefaHistorico> TarefaHistoricos { get; set; }
    }
}
