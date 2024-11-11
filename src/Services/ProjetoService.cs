using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.API.Models.Dtos;
using AutoMapper;
using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;

namespace GerenciadorDeTarefas.API.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;
        private readonly IMapper _mapper;

        public ProjetoService(IProjetoRepository projetoRepository, IMapper mapper)
        {
            _projetoRepository = projetoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Projeto>> GetAllAsync()
        {
            return await _projetoRepository.GetAllAsync();
        }

        public async Task<Projeto> GetByIdAsync(int id)
        {
            return await _projetoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Projeto>> GetByUsuarioAsync(int usuarioId)
        {
            return await _projetoRepository.GetByUsuarioAsync(usuarioId);
        }

        public async Task<Projeto> InsertAsync(ProjetoDto projetoDto)
        {
            var projeto = _mapper.Map<Projeto>(projetoDto);
            projeto.DataCriacao = DateTime.Now;

            return await _projetoRepository.AddAsync(projeto);
        }

        public async Task UpdateAsync(int id, ProjetoDto projetoDto)
        {
            var projeto = await _projetoRepository.GetByIdAsync(id);

            if (projeto == null)
            {
                throw new Exception($"Nenhum projeto encontrado com o ID {id}.");
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
