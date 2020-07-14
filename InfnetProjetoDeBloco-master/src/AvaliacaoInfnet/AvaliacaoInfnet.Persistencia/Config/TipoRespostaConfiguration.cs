using AvaliacaoInfnet.Domain;
using System.Data.Entity.ModelConfiguration;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class TipoRespostaConfiguration : EntityTypeConfiguration<TipoResposta>
    {
        public TipoRespostaConfiguration()
        {
            HasKey(x => x.Id);
            HasMany(x => x.Perguntas).WithMany(x => x.TipoRespostas);
            HasMany(x => x.AvaliacaoRespostas).WithMany(x => x.TipoRespostas);
        }
    }
}
