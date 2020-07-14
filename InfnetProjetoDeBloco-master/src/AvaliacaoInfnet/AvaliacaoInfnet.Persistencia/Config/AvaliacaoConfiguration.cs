using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class AvaliacaoConfiguration : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoConfiguration()
        {
            HasKey(c => c.Id);
            HasMany(c => c.Perguntas).WithMany(x => x.Avaliacoes);
        }
    }
}
