using TaskManager.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskManager.API.Data;
using TaskManager.API.Data.Repositories;

namespace TaskManager.API.Configurations
{
    public static class ApplicationConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
