using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<IEnumerable<Projeto>> GetAllAsync();
        Task<Projeto> GetByIdAsync(int id);
        Task<IEnumerable<Projeto>> GetByUsuarioAsync(int usuarioId);
        Task<Projeto> InsertAsync(ProjetoDto projetoDto);
        Task UpdateAsync(int id, ProjetoDto projetoDto);
        Task DeleteAsync(int id);
    }
}
