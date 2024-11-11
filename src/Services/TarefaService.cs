using AutoMapper;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Services.Interfaces;

namespace GerenciadorDeTarefas.API.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _tarefaRepository.GetAllAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _tarefaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> GetByProjetoAsync(int projetoId)
        {
            return await _tarefaRepository.GetByProjetoAsync(projetoId);
        }

        public async Task<Tarefa> InsertAsync(TarefaCreateDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);

            return await _tarefaRepository.AddAsync(tarefa);
        }

        public async Task UpdateAsync(int id, TarefaCreateDto tarefaDto)
        {
            var tarefa = await _tarefaRepository.GetByIdAsync(id);

            if (tarefa == null)
            {
                throw new Exception($"Nenhuma tarefa encontrada com o ID {id}.");
            }

            tarefa = _mapper.Map<Tarefa>(tarefaDto);

            await _tarefaRepository.UpdateAsync(tarefa);
        }

        public async Task DeleteAsync(int id)
        {
            await _tarefaRepository.DeleteAsync(id);
        }
    }
}
