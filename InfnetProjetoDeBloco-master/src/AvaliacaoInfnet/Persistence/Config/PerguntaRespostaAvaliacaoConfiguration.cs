using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class PerguntaRespostaAvaliacaoConfiguration : IEntityTypeConfiguration<PerguntaRespostaAvaliacao>
    {
        public void Configure(EntityTypeBuilder<PerguntaRespostaAvaliacao> builder)
        {
            builder.HasKey(x => x.IdAvalicao);
            //HasKey(x => x.IdPergunta);
            //HasKey(x => x.IdTipoResposta);
        }
       
    }
}
