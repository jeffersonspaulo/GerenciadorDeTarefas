using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Data.Repositories.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<List<UsuarioMediaDto>> CalcularMediaTarefasConcluidasPeriodoAsync(TarefaStatus status, DateTime dataInicio, DateTime dataFim);
        Task<List<ProjetoQuantidadeDto>> ObterTarefasConcluidasPorProjetoAsync(int projetoId, DateTime dataInicio, DateTime dataFim);
        Task<List<Usuario>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<double> CalcularMediaTarefasCriadasPorDiaAsync();
        Task<List<Projeto>> ObterProjetosAtrasadosAsync();
    }
}
