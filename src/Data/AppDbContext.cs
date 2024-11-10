using TaskManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Usuarios { get; set; }
        public DbSet<TaskManager.Models.Entities.Task> Tarefas { get; set; }
        public DbSet<Project> Projetos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskManager.Models.Entities.Task>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId);
        }
    }
}
