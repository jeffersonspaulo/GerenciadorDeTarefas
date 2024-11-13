using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly ILogger<RelatorioService> _logger;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IValidationService _validationService;

        public RelatorioService(ILogger<RelatorioService> logger, IRelatorioRepository relatorioRepository, IValidationService validationService)
        {
            _logger = logger;
            _relatorioRepository = relatorioRepository;
            _validationService = validationService;
        }

        public async Task<Result<IEnumerable<RelatorioUsuarioMediaDto>>> CalcularMediaTarefasConcluidasPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var resultado = await _relatorioRepository.CalcularMediaTarefasConcluidasPeriodoAsync(dataInicio, dataFim);

                return Result<IEnumerable<RelatorioUsuarioMediaDto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<RelatorioUsuarioMediaDto>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<IEnumerable<ProjetoQuantidadeDto>>> ObterTarefasConcluidasPorProjetoAsync(RelatorioTarefasPorProjetoDto relatorioDto)
        {
            try
            {
                var resultado = await _relatorioRepository.ObterTarefasConcluidasPorProjetoAsync(relatorioDto);

                return Result<IEnumerable<ProjetoQuantidadeDto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<ProjetoQuantidadeDto>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<IEnumerable<RelatorioUsuarioQuantidade>>> ObterUsuariosMaisProdutivosPorPeriodoAsync(DateTime dataInicio, DateTime dataFim)
        {
            try
            {
                var resultado = await _relatorioRepository.ObterUsuariosMaisProdutivosPorPeriodoAsync(dataInicio, dataFim);
                return Result<IEnumerable<RelatorioUsuarioQuantidade>>.Success(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<RelatorioUsuarioQuantidade>>.Failure("Ocorreu um erro durante a requisição.");
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
                _logger.LogError(ex, ex.Message);
                return Result<double>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<IEnumerable<Projeto>>> ObterProjetosAtrasadosAsync()
        {
            try
            {
                var resultado = await _relatorioRepository.ObterProjetosAtrasadosAsync();

                return Result<IEnumerable<Projeto>>.Success(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<Projeto>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }
    }
}
