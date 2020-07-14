using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Persistencia.Config;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AvaliacaoInfnet.Persistencia.Context
{
    public class AvaliacaoInfnetContext : DbContext
    {
        public AvaliacaoInfnetContext() : base(nameof(AvaliacaoInfnet))
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<String>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<String>().Configure(p => p.HasMaxLength(100));

            /*
            Adicionar configurações específicas por entidade:
            */
            modelBuilder.Configurations.Add(new AvaliacaoConfiguration());
            modelBuilder.Configurations.Add(new AvaliacaoRespostaConfiguration());
            modelBuilder.Configurations.Add(new EntrevistadoConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
            modelBuilder.Configurations.Add(new PerguntaConfiguration());
            modelBuilder.Configurations.Add(new PerguntaRespostaAvaliacaoConfiguration());
            modelBuilder.Configurations.Add(new TipoRespostaConfiguration());
        }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<AvaliacaoResposta> AvaliacaoRespostas { get; set; }

        public DbSet<Entrevistado> Entrevistados { get; set; }

        public DbSet<Perfil> Perfis { get; set; }

        public DbSet<Pergunta> Perguntas { get; set; }

        public DbSet<TipoResposta> TipoRespostas { get; set; }

        public DbSet<PerguntaRespostaAvaliacao> PerguntaRespostaAvaliacoes { get; set; }

    }
}
