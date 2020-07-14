using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    class AvaliacaoRespostaConfiguration : EntityTypeConfiguration<AvaliacaoResposta>
    {
        public AvaliacaoRespostaConfiguration()
        {
            HasKey(x => x.Id);
            HasMany(x => x.PerguntaResposta);
        }
    }
}
