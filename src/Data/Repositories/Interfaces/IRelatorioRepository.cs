using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;

namespace GerenciadorDeTarefas.API.Data.Repositories.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<RelatorioUsuarioMediaDto>> CalcularMediaTarefasConcluidasPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<ProjetoQuantidadeDto>> ObterTarefasConcluidasPorProjetoAsync(RelatorioTarefasPorProjetoDto relatorioDto);
        Task<IEnumerable<RelatorioUsuarioQuantidade>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<double> CalcularMediaTarefasCriadasPorDiaAsync();
        Task<IEnumerable<Projeto>> ObterProjetosAtrasadosAsync();
    }
}
