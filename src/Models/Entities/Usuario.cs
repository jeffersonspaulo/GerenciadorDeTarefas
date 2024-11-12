using GerenciadorDeTarefas.API.Models.Entities;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        public List<TarefaHistorico> TarefaHistoricos { get; set; }
    }
}
