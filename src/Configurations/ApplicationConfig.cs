using GerenciadorDeTarefas.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.API.Data;
using GerenciadorDeTarefas.API.Data.Repositories;
using GerenciadorDeTarefas.API.Services.Interfaces;
using GerenciadorDeTarefas.API.Services;

namespace GerenciadorDeTarefas.API.Configurations
{
    public static class ApplicationConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ITarefaService, TarefaService>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
