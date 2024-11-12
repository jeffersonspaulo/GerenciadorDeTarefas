using AutoMapper;
using GerenciadorDeTarefas.API.Controllers;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Utils;

namespace GerenciadorDeTarefas.API.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ILogger<TarefaService> _logger;
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        private readonly ValidationService _validationService;

        public TarefaService(ILogger<TarefaService> logger, ITarefaRepository tarefaRepository, IMapper mapper, ValidationService validationService)
        {
            _logger = logger;
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
            _validationService = validationService;
        }

        public async Task<Result<IEnumerable<Tarefa>>> GetAllAsync()
        {
            try
            {
                var tarefas = await _tarefaRepository.GetAllAsync();

                if (tarefas == null)
                {
                    return Result<IEnumerable<Tarefa>>.Failure("Nenhuma tarefa encontrada.");
                }

                return Result<IEnumerable<Tarefa>>.Success(tarefas);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<Tarefa>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<Tarefa>> GetByIdAsync(int id)
        {
            try
            {
                var tarefa = await _tarefaRepository.GetByIdAsync(id);

                if (tarefa == null)
                {
                    return Result<Tarefa>.Failure($"Nenhuma tarefa encontrada com o ID {id}.");
                }

                return Result<Tarefa>.Success(tarefa);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<Tarefa>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<IEnumerable<Tarefa>>> GetByProjetoAsync(int projetoId)
        {
            try
            {
                var tarefas = await _tarefaRepository.GetByProjetoAsync(projetoId);

                if (tarefas == null)
                {
                    return Result<IEnumerable<Tarefa>>.Failure("Nenhuma tarefa encontrada.");
                }

                return Result<IEnumerable<Tarefa>>.Success(tarefas);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<IEnumerable<Tarefa>>.Failure("Ocorreu um erro durante a requisição.");
            }
        }

        public async Task<Result<Tarefa>> InsertAsync(TarefaCreateDto tarefaDto)
        {
            try
            {
                var resultValidation = _validationService.Validate(tarefaDto);

                if (!resultValidation.IsSuccess)
                {
                    return Result<Tarefa>.Failure(resultValidation.ErrorMessage);
                }

                var tarefasExistentes = await _tarefaRepository.GetByProjetoAsync(tarefaDto.ProjetoId);

                if (tarefasExistentes.Count() >= 20)
                {
                    return Result<Tarefa>.Failure("O projeto já possui o limite máximo de 20 tarefas. Não é possível adicionar mais tarefas.");
                }

                var tarefa = _mapper.Map<Tarefa>(tarefaDto);
                tarefa.DataCriacao = DateTime.Now;

                var tarefaCreated = await _tarefaRepository.AddAsync(tarefa);

                await _tarefaRepository.AddHistorico(tarefa, tarefaDto.UsuarioId, tarefaDto.Comentario); 

                return Result<Tarefa>.Success(tarefaCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Result<Tarefa>.Failure("Ocorreu um erro durante a requisição.");
            }

        }

        public async Task<Result> UpdateAsync(int id, TarefaUpdateDto tarefaDto)
        {
            try
            {
                var resultValidation = _validationService.Validate(tarefaDto);

                if (!resultValidation.IsSuccess)
                {
                    return Result.Failure(resultValidation.ErrorMessage);
                }

                var tarefa = await _tarefaRepository.GetByIdAsync(id);

                if (tarefa == null)
                {
                    return Result.Failure($"Nenhuma tarefa encontrada com o ID {id}.");
                }

                tarefa = _mapper.Map<Tarefa>(tarefaDto);

                await _tarefaRepository.UpdateAsync(tarefa);

                await _tarefaRepository.AddHistorico(tarefa, tarefaDto.UsuarioId, tarefaDto.Comentario);

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
                await _tarefaRepository.DeleteAsync(id);

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
