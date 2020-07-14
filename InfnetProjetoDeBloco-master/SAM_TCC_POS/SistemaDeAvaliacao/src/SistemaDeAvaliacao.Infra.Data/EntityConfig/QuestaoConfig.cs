using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeAvaliacao.Infra.Data.EntityConfig
{
    public class QuestaoConfig : EntityTypeConfiguration<Questao>
    {
        public QuestaoConfig()
        {
            HasKey(q => q.QuestaoId);

            Property(q => q.Descricao)
                .IsRequired()
                .HasMaxLength(200);

            HasRequired(q => q.Categoria)
                .WithMany(q => q.Questoes)
                .HasForeignKey(q => q.CategoriaId);
        }
    }
}
