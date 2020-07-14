using SistemaDeAvaliacao.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeAvaliacao.Infra.Data.EntityConfig
{
    public class AvaliacaoConfig : EntityTypeConfiguration<Avaliacao>
    {
        public AvaliacaoConfig()
        {
            HasKey(a => a.AvaliacaoId);

            Property(a => a.CodigoAcesso)
                .IsRequired();

            Property(a => a.Objetivo)
                .IsRequired()
                .HasMaxLength(300);

            Property(a => a.DataInicio)
                .IsRequired();

            Property(a => a.DataTermino)
                .IsRequired();

            Property(a => a.Curso)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.TurmaId)
                .IsRequired();

            Property(a => a.Professor)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(a => a.Questoes)
                .WithMany(q => q.Avaliacoes)
                .Map(a =>
                {
                    a.MapLeftKey("AvaliacaoId");
                    a.MapRightKey("QuestaoId");
                    a.ToTable("AvaliacaoQuestao");
                });
        }
    }
}
