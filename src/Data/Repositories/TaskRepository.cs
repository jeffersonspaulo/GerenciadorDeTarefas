using TaskManager.Data.Repositories;
using TaskManager.Models.Entities;

namespace TaskManager.API.Data.Repositories
{
    public class TaskRepository : Repository<TaskManager.Models.Entities.Task>
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
