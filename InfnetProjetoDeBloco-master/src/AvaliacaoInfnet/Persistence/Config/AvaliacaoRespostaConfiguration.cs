using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    class AvaliacaoRespostaConfiguration : IEntityTypeConfiguration<AvaliacaoResposta>
    {
        public void Configure(EntityTypeBuilder<AvaliacaoResposta> builder)
        {
            builder.HasKey(a => a.Id);
            //HasMany(c => c.Perguntas).WithMany(x => x.Avaliacoes);

        }

    }
}
