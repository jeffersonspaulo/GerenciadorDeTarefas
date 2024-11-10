namespace GerenciadorDeTarefas.API.Models.Dtos
{
    public class TarefaDto
    {
        public int ProjetoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public int TarefaStatusId { get; set; }
    }
}
