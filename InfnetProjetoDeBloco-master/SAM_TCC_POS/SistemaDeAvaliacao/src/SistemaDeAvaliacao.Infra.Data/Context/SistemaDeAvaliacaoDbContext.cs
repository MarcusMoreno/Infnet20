using System.Data.Entity;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Infra.Data.EntityConfig;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System;

namespace SistemaDeAvaliacao.Infra.Data.Context
{
    /// <summary>
    /// Contexto da Infra, não do Identity
    /// </summary>
    public class SistemaDeAvaliacaoDbContext : DbContext
    {
        public SistemaDeAvaliacaoDbContext()
            : base("SistemaDeAvaliacaoDb")
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<AvaliacaoResposta> AvaliacaoRespostas { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<QuestaoCategoria> QuestaoCategorias { get; set; }
        public DbSet<OpcaoResposta> OpcaoRepostas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new QuestaoCategoriaConfig());
            modelBuilder.Configurations.Add(new QuestaoConfig());
            modelBuilder.Configurations.Add(new AvaliacaoConfig());
            modelBuilder.Configurations.Add(new AvaliacaoRespostaConfig());
            modelBuilder.Configurations.Add(new OpcaoRespostaConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
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