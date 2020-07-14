using System.Collections.Generic;

namespace AvaliacaoInfnet.Domain
{
    public class Perfil
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Entrevistado> Entrevistados { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
