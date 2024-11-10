using TaskManager.Data.Repositories;
using TaskManager.Models.Entities;

namespace TaskManager.API.Data.Repositories
{
    public class ProjectRepository : Repository<Project>
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}