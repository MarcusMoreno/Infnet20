using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class EntrevistadoConfiguration : IEntityTypeConfiguration<Entrevistado>
    {

        public void Configure(EntityTypeBuilder<Entrevistado> builder)
        {
            builder.HasKey(a => a.Id);
            //HasKey(x => x.Id);

            //HasMany(x => x.Perfil);
            //HasMany(x => x.AvaliacaoRespostas);
            //HasMany(x => x.Avaliacoes);
        }

    }
}