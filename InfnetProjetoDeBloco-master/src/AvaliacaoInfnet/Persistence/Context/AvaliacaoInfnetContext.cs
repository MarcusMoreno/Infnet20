using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Persistencia.Config;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoInfnet.Persistencia.Context
{
    public class AvaliacaoInfnetContext : DbContext
    {
        public AvaliacaoInfnetContext()
        { }

        public AvaliacaoInfnetContext(DbContextOptions<AvaliacaoInfnetContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ContosoDDD;Trusted_Connection = True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.ApplyConfiguration(new AvaliacaoConfiguration());
            modelBuilder.ApplyConfiguration(new AvaliacaoRespostaConfiguration());
            modelBuilder.ApplyConfiguration(new EntrevistadoConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
            modelBuilder.ApplyConfiguration(new PerguntaConfiguration());
            modelBuilder.ApplyConfiguration(new PerguntaRespostaAvaliacaoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoRespostaConfiguration());
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
