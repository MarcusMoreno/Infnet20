using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class PerfilConfiguration : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfiguration()
        {
            HasKey(x => x.Id);
            HasMany(x => x.Entrevistados);
            HasMany(x => x.Avaliacoes);
        }
    }
}
