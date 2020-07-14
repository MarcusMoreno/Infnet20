using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class PerfilConfiguration : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.HasKey(a => a.Id);
            //HasMany(x => x.Entrevistados);
            //HasMany(x => x.Avaliacoes);
        }

    }
}
