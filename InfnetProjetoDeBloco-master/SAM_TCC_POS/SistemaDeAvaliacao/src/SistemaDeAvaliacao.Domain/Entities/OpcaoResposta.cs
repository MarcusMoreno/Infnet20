using System.Collections;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Entities
{
    public class OpcaoResposta
    {
        public int OpcaoRespostaId { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<AvaliacaoResposta> AvaliacaoRespostas { get; set; }
    }
}
