using API_Alunos.Context.Map;
using API_Alunos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AlunoModel>? Alunos { get; set; }
        public DbSet<TurmaModel>? Turmas { get; set; }
        public DbSet<MatriculaModel>? Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
