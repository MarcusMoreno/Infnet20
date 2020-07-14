using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class TipoRespostaConfiguration : IEntityTypeConfiguration<TipoResposta>
    {
        public void Configure(EntityTypeBuilder<TipoResposta> builder)
        {
            builder.HasKey(a => a.Id);
            //HasMany(x => x.Perguntas).WithMany(x => x.TipoRespostas);
            //HasMany(x => x.AvaliacaoRespostas).WithMany(x => x.TipoRespostas);
        }
    }
}
