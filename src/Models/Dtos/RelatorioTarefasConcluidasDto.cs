using GerenciadorDeTarefas.API.Models.Enums;

namespace GerenciadorDeTarefas.API.Models.Dtos
{
    public class RelatorioTarefasConcluidasDto
    {
        public TarefaStatus Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
