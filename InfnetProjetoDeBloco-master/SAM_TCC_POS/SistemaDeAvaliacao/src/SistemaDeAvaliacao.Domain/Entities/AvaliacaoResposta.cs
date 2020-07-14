using System;

namespace SistemaDeAvaliacao.Domain.Entities
{
    public class AvaliacaoResposta
    {
        public int AvaliacaoRespostaId { get; set; }
        public int AvaliacaoId { get; set; }
        public int MatriculaAluno { get; set; }
        public string NomeAluno { get; set; }
        public int QuestaoId { get; set; }
        public int Resposta { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Avaliacao Avaliacao { get; set; }
        public virtual Questao Questao { get; set; }
        public virtual OpcaoResposta OpcaoResposta { get; set; }
    }
}