using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Data.Repositories.Interfaces
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<UsuarioMediaDto>> CalcularMediaTarefasConcluidasPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<IEnumerable<ProjetoQuantidadeDto>> ObterTarefasConcluidasPorProjetoAsync(RelatorioTarefasPorProjetoDto relatorioDto);
        Task<IEnumerable<Usuario>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<double> CalcularMediaTarefasCriadasPorDiaAsync();
        Task<IEnumerable<Projeto>> ObterProjetosAtrasadosAsync();
    }
}
