using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class PerguntaRespostaAvaliacaoConfiguration : EntityTypeConfiguration<PerguntaRespostaAvaliacao>
    {
        public PerguntaRespostaAvaliacaoConfiguration()
        {
            HasKey(x => x.IdAvalicao);
            HasKey(x => x.IdPergunta);
            HasKey(x => x.IdTipoResposta);
        }
    }
}
