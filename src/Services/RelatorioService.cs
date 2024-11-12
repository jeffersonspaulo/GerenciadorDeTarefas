using AutoMapper;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Utils;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ILogger<TarefaService> _logger;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly ValidationService _validationService;

        public RelatorioService(ILogger<TarefaService> logger, IRelatorioRepository relatorioRepository, ValidationService validationService)
        {
            _logger = logger;
            _relatorioRepository = relatorioRepository;
            _validationService = validationService;
        }

        public async Task<Result<List<UsuarioMediaDto>>> CalcularMediaTarefasConcluidasPeriodoAsync(TarefaStatus status, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var resultado = await _relatorioRepository.CalcularMediaTarefasConcluidasPeriodoAsync(status, dataInicio, dataFim);

                return Result<List<UsuarioMediaDto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                return Result<List<UsuarioMediaDto>>.Failure($"Erro ao calcular a média de tarefas concluídas: {ex.Message}");
            }
        }

        public async Task<Result<List<ProjetoQuantidadeDto>>> ObterTarefasConcluidasPorProjetoAsync(int projetoId, DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var resultado = await _relatorioRepository.ObterTarefasConcluidasPorProjetoAsync(projetoId, dataInicio, dataFim);

                return Result<List<ProjetoQuantidadeDto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                return Result<List<ProjetoQuantidadeDto>>.Failure($"Erro ao obter tarefas concluídas por projeto: {ex.Message}");
            }
        }

        public async Task<Result<List<Usuario>>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var resultado = await _relatorioRepository.ObterUsuariosMaisProdutivosPorPeriodoAsync(dataInicio, dataFim);
                return Result<List<Usuario>>.Success(resultado);
            }
            catch (Exception ex)
            {
                return Result<List<Usuario>>.Failure($"Erro ao obter usuários mais produtivos: {ex.Message}");
            }
        }

        public async Task<Result<double>> CalcularMediaTarefasCriadasPorDiaAsync()
        {
            try
            {
                var resultado = await _relatorioRepository.CalcularMediaTarefasCriadasPorDiaAsync();

                return Result<double>.Success(resultado);
            }
            catch (Exception ex)
            {
                return Result<double>.Failure($"Erro ao calcular a média de tarefas criadas: {ex.Message}");
            }
        }

        public async Task<Result<List<Projeto>>> ObterProjetosAtrasadosAsync()
        {
            try
            {
                var resultado = await _relatorioRepository.ObterProjetosAtrasadosAsync();

                return Result<List<Projeto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                return Result<List<Projeto>>.Failure($"Erro ao obter projetos atrasados: {ex.Message}");
            }
        }
    }
}
