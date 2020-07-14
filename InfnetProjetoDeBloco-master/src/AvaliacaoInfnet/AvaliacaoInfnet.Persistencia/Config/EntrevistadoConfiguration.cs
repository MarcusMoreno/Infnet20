using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class EntrevistadoConfiguration : EntityTypeConfiguration<Entrevistado>
    {
        public EntrevistadoConfiguration()
        {
            HasKey(x => x.Id);
            
            HasMany(x => x.Perfil);
            HasMany(x => x.AvaliacaoRespostas);
            HasMany(x => x.Avaliacoes);
        }
    }
}
