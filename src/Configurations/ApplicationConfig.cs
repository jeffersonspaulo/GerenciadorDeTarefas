using GerenciadorDeTarefas.Data.Repositories.Interfaces;
using GerenciadorDeTarefas.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.API.Data;

namespace GerenciadorDeTarefas.Configurations
{
    public static class ApplicationConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
