using Newtonsoft.Json;

namespace GerenciadorDeTarefas.API.Models.Entities
{
    public class Projeto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Tarefa> Tarefas { get; set; }
    }
}
