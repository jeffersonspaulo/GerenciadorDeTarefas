using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.API.Utils;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<Result<IEnumerable<UsuarioMediaDto>>> CalcularMediaTarefasConcluidasPeriodoAsync(TarefaStatus status, DateTime dataInicio, DateTime dataFim);
        Task<Result<IEnumerable<ProjetoQuantidadeDto>>> ObterTarefasConcluidasPorProjetoAsync(int projetoId, DateTime dataInicio, DateTime dataFim);
        Task<Result<IEnumerable<Usuario>>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<Result<double>> CalcularMediaTarefasCriadasPorDiaAsync();
        Task<Result<IEnumerable<Projeto>>> ObterProjetosAtrasadosAsync();
    }
}
