using TaskManager.API.Models.Enums;
using Newtonsoft.Json;

namespace TaskManager.Models.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public API.Models.Enums.TaskStatus Status { get; set; }

        [JsonIgnore]
        public Project Projeto { get; set; }
    }
}
