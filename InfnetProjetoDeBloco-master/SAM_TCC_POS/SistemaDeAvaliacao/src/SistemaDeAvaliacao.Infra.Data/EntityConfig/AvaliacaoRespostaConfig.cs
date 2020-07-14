using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeAvaliacao.Infra.Data.EntityConfig
{
    public class AvaliacaoRespostaConfig : EntityTypeConfiguration<AvaliacaoResposta>
    {
        public AvaliacaoRespostaConfig()
        {
            HasKey(r => r.AvaliacaoRespostaId);

            Property(r => r.MatriculaAluno)
                .IsRequired();

            Property(r => r.NomeAluno)
                .IsRequired()
                .HasMaxLength(100);

            Property(r => r.Resposta)
                .IsRequired();

            Property(r => r.QuestaoId)
                .IsRequired();

            HasRequired(r => r.Avaliacao)
                .WithMany(a => a.Respostas)
                .HasForeignKey(r => r.AvaliacaoId);

            HasRequired(r => r.Questao)
                .WithMany(q => q.Respostas)
                .HasForeignKey(r => r.QuestaoId);

            HasRequired(r => r.OpcaoResposta)
                .WithMany(o => o.AvaliacaoRespostas)
                .HasForeignKey(r => r.Resposta);
        }
    }
}
