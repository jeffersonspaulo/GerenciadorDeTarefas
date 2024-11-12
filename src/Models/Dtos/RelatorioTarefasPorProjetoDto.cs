namespace GerenciadorDeTarefas.API.Models.Dtos
{
    public class RelatorioTarefasPorProjetoDto
    {
        public int ProjetoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
