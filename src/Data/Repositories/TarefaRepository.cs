using GerenciadorDeTarefas.Data.Repositories;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Data.Repositories
{
    public class TarefaRepository : Repository<Tarefa>
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
