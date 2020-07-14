using SistemaDeAvaliacao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeAvaliacao.Infra.Data.EntityConfig
{
    public class OpcaoRespostaConfig : EntityTypeConfiguration<OpcaoResposta>
    {
        public OpcaoRespostaConfig()
        {
            HasKey(o => o.OpcaoRespostaId);

            Property(o => o.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
