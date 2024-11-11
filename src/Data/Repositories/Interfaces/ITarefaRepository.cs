using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.Data.Repositories.Interfaces;

namespace GerenciadorDeTarefas.API.Data.Repositories.Interfaces
{
    public interface ITarefaRepository : IRepository<Tarefa>
    {
        Task<IEnumerable<Tarefa>> GetByProjetoAsync(int projetoId);
    }
}
