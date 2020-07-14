using System.Collections.Generic;

namespace AvaliacaoInfnet.Domain
{
    public class Pergunta
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<TipoResposta> TipoRespostas { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }

        public virtual ICollection<AvaliacaoResposta> Respostas { get; set; }
    }
}
