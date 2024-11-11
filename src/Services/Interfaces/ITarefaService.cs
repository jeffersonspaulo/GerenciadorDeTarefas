using GerenciadorDeTarefas.API.Models.Dtos;
using GerenciadorDeTarefas.API.Models.Entities;

namespace GerenciadorDeTarefas.API.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task<IEnumerable<Tarefa>> GetByProjetoAsync(int projetoId);
        Task<Tarefa> InsertAsync(TarefaCreateDto tarefaDto);
        Task UpdateAsync(int id, TarefaCreateDto tarefaDto);
        Task DeleteAsync(int id);
    }
}
