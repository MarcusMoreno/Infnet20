using System.Collections.Generic;

namespace AvaliacaoInfnet.Domain
{
    public class Entrevistado
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool Status { get; set; }

        public string Senha { get; set; }

        //Relacionamentos

        public virtual ICollection<Perfil> Perfil { get; set; }

        public virtual ICollection<AvaliacaoResposta> AvaliacaoRespostas { get; set; }

        public virtual ICollection<Avaliacao> Avaliacoes { get; set; }
    }
}
