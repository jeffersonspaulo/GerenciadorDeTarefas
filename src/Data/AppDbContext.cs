using GerenciadorDeTarefas.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeTarefas.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<TarefaHistorico> TarefasHistorico { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Projeto>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Descricao)
                .HasMaxLength(500);

            modelBuilder.Entity<Projeto>()
                .HasMany(p => p.Tarefas)
                .WithOne(t => t.Projeto)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarefa>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Descricao)
                .HasMaxLength(500);

            modelBuilder.Entity<TarefaHistorico>()
                .HasKey(th => th.Id);

            modelBuilder.Entity<TarefaHistorico>()
                .Property(th => th.Comentario)
                .HasMaxLength(1000);

            modelBuilder.Entity<TarefaHistorico>()
                .HasOne(th => th.Tarefa)
                .WithMany(t => t.TarefaHistoricos)
                .HasForeignKey(th => th.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
