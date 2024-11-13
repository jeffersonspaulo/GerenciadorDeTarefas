using GerenciadorDeTarefas.API.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.API.Data.Repositories
{
    public class ProjetoRepository : Repository<Projeto>, IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projeto>> GetByUsuarioAsync(string usuarioId)
        {
            return await _context.Projetos
                .Where(item => item.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
