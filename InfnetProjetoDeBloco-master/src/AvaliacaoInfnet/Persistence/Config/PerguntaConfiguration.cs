using AvaliacaoInfnet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoInfnet.Persistencia.Config
{
    public class PerguntaConfiguration : IEntityTypeConfiguration<Pergunta>
    {
        public void Configure(EntityTypeBuilder<Pergunta> builder)
        {
            builder.HasKey(a => a.Id);
            ///*
            // Definição da relação m:n entre Pergunta e TipoResposta:
            // */
            //HasMany(c => c.TipoRespostas) //Um pergunta possui uma lista de TipoRespostas
            //    .WithMany(p => p.Perguntas) //E cada tipoResposta da pergunta possui uma lista de pergunta
            //    .Map(m => //O relacionamento entre pergunta e tipoResposta será mapeado numa terceira tabela
            //    {
            //        /*
            //        Como este mapeamento está sendo feito a partir de Curso para professor, o lado ESQUERDO do relacionamento é Curso. Professor é o lado DIREITO do relacionamento
            //        */
            //        m.MapLeftKey("PerguntaId"); //O nome da chave estrangeira oriunda de pergunta será perguntaId
            //        m.MapRightKey("TipoRespostaId"); //O nome da chave estrangeira oriunda de TipoResposta será TipoRespostaId
            //        m.ToTable("PerguntaTipoResposta"); //Nome da tabela de relacionamento.
            //    });
            //HasMany(x => x.Avaliacoes).WithMany(x => x.Perguntas);
            //HasMany(x => x.TipoRespostas).WithMany(x => x.Perguntas);
        }

    }
}
