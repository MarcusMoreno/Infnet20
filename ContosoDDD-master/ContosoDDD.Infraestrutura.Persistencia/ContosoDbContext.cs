using ContosoDDD.Dominio.Entidade;
using ContosoDDD.Infraestrutura.Persistencia.Configurações;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ContosoDDD.Infraestrutura.Persistencia
{
    public class ContosoDbContext : DbContext
    {
        public ContosoDbContext() { }

        public ContosoDbContext(DbContextOptions<ContosoDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ContosoDDD;Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                if (prop.GetColumnType() == null)
                    prop.SetColumnType("varchar(255)");
            }

            modelBuilder.ApplyConfiguration(new AlunoConfiguracao());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}
