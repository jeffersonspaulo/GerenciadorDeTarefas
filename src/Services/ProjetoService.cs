using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Dtos;
using Task = System.Threading.Tasks.Task;
using AutoMapper;

namespace GerenciadorDeTarefas.API.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IRepository<Projeto> _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IRepository<Projeto> projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task InsertAsync(ProjetoDto projetoDto)
        {
            var projeto = _mapper.Map<Projeto>(projetoDto);
            projeto.DataCriacao = DateTime.Now;

            await _projetoRepository.AddAsync(projeto);
        }

        public async Task UpdateAsync(int id, ProjetoDto projetoDto)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
            {
                throw new Exception($"Project with ID {id} not found.");
            }

            projeto = _mapper.Map<Projeto>(projetoDto);

            await _projetoRepository.UpdateAsync(projeto);
        }

        public async Task DeleteAsync(int id)
        {
            await _projetoRepository.DeleteAsync(id);
        }
    }
}
