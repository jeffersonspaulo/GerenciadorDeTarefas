using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Dtos;
using AutoMapper;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Enums;
using GerenciadorDeTarefas.API.Utils;
using GerenciadorDeTarefas.API.Data.Repositories;

namespace GerenciadorDeTarefas.API.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly ILogger<ProjetoService> _logger;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;
        private readonly ValidationService _validationService;

        public ProjetoService(ILogger<ProjetoService> logger, IProjetoRepository projetoRepository, IMapper mapper, ValidationService validationService)
        {
            _logger = logger;
            _projetoRepository = projetoRepository;
            _mapper = mapper;
            _validationService = validationService;
        }

        public async Task<Result<IEnumerable<Projeto>>> GetAllAsync()
        {
            try
            {
                var projetos = await _projetoRepository.GetAllAsync();

                if (projetos == null)
                {
                    return Result<IEnumerable<Projeto>>.Failure("Nenhum projeto encontrado.");
                }

                return Result<IEnumerable<Projeto>>.Success(projetos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<Projeto>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<Projeto>> GetByIdAsync(int id)
        {
            try
            {
                var projeto = await _projetoRepository.GetByIdAsync(id);

                if (projeto == null)
                {
                    return Result<Projeto>.Failure($"Nenhum projeto encontrado com o ID {id}.");
                }

                return Result<Projeto>.Success(projeto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<Projeto>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<IEnumerable<Projeto>>> GetByUsuarioAsync(int usuarioId)
        {
            try {
                var projetos = await _projetoRepository.GetByUsuarioAsync(usuarioId);

                if (projetos == null)
                {
                    return Result<IEnumerable<Projeto>>.Failure("Nenhum projeto encontrado.");
                }

                return Result<IEnumerable<Projeto>>.Success(projetos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<Projeto>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<Projeto>> InsertAsync(ProjetoDto projetoDto)
        {
            try
            {
                _validationService.Validate(projetoDto);

                var projeto = _mapper.Map<Projeto>(projetoDto);
                projeto.DataCriacao = DateTime.Now;

                var projetoCreated = await _projetoRepository.AddAsync(projeto);

                return Result<Projeto>.Success(projetoCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<Projeto>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result> UpdateAsync(int id, ProjetoDto projetoDto)
        {
            try
            {
                _validationService.Validate(projetoDto);

                var projeto = await _projetoRepository.GetByIdAsync(id);

                if (projeto == null)
                {
                    throw new Exception($"Nenhum projeto encontrado com o ID {id}.");
                }

                projeto = _mapper.Map<Projeto>(projetoDto);

                await _projetoRepository.UpdateAsync(projeto);

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result.Failure("Ocorreu um erro durante a requisição.");
            }            
        }

        public async Task<Result> DeleteAsync(int id)
        {
            try
            {
                var projeto = await _projetoRepository.GetByIdWithIncludesAsync(id, i => i.Tarefas);

                if (projeto == null)
                {
                    return Result.Failure($"Nenhum projeto encontrado com o ID {id}.");
                }

                var possuiTarefaPendente = projeto.Tarefas.Any(t => t.TarefaStatus == TarefaStatus.Pendente);

                if (possuiTarefaPendente)
                {
                    return Result.Failure($"O projeto não pode ser deletado porque possui tarefas com status pendente. Conclua ou remova as tarefas pendentes e tente novamente. ");
                }

                await _projetoRepository.DeleteAsync(id);

                return Result.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result.Failure("Ocorreu um erro durante a requisição.");
            }            
        }
    }
}
