using GerenciadorDeTarefas.API.Models.Entities;
using GerenciadorDeTarefas.Data.Repositories.Interfaces;

namespace GerenciadorDeTarefas.API.Data.Repositories.Interfaces
{
    public interface IProjetoRepository : IRepository<Projeto>
    {
        Task<IEnumerable<Projeto>> GetByUsuarioAsync(int usuarioId);
    }
}
