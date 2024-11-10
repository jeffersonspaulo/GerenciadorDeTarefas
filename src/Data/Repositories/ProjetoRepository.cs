using GerenciadorDeTarefas.Data.Repositories;
using GerenciadorDeTarefas.Models.Entities;

namespace GerenciadorDeTarefas.API.Data.Repositories
{
    public class ProjetoRepository : Repository<Projeto>
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
