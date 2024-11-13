using GerenciadorDeTarefas.API.Models.Enums;

namespace GerenciadorDeTarefas.API.Models.Dtos
{
    public class TarefaUpdateDto
    {
        public int ProjetoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public TarefaStatus TarefaStatus { get; set; }
        public string Comentario { get; set; }
    }
}
