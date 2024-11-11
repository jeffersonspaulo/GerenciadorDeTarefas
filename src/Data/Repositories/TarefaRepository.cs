using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.API.Data.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetByProjetoAsync(int projetoId)
        {
            return await _context.Tarefas
                .Where(item => item.ProjetoId == projetoId)
                .ToListAsync();
        }
    }
}
