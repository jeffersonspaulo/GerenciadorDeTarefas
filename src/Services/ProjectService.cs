using TaskManager.API.Services.Interfaces;
using TaskManager.Data.Repositories.Interfaces;
using TaskManager.Models.Entities;

namespace TaskManager.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IRepository<Project> _projetoRepository;

        public ProjectService(IRepository<Project> projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }
    }
}
