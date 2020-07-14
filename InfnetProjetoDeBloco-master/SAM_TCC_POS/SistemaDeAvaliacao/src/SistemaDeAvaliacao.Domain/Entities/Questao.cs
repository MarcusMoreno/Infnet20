using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Entities
{
    public class Questao
    {
        public int QuestaoId { get; set; }
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }

        public virtual QuestaoCategoria Categoria { get; set; }
        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
        public virtual ICollection<AvaliacaoResposta> Respostas { get; set; }
    }
}