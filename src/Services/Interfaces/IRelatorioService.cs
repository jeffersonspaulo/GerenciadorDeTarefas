using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.API.Utils;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface IRelatorioService
    {
        Task<Result<List<UsuarioMediaDto>>> CalcularMediaTarefasConcluidasPeriodoAsync(TarefaStatus status, DateTime dataInicio, DateTime dataFim);
        Task<Result<List<ProjetoQuantidadeDto>>> ObterTarefasConcluidasPorProjetoAsync(int projetoId, DateTime dataInicio, DateTime dataFim);
        Task<Result<List<Usuario>>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim);
        Task<Result<double>> CalcularMediaTarefasCriadasPorDiaAsync();
        Task<Result<List<Projeto>>> ObterProjetosAtrasadosAsync();
    }
}
