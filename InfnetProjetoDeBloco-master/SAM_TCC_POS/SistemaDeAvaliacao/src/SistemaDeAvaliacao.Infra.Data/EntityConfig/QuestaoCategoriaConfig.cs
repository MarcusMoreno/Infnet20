using SistemaDeAvaliacao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeAvaliacao.Infra.Data.EntityConfig
{
    public class QuestaoCategoriaConfig : EntityTypeConfiguration<QuestaoCategoria>
    {
        public QuestaoCategoriaConfig()
        {
            HasKey(q => q.CategoriaId);

            Property(q => q.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
