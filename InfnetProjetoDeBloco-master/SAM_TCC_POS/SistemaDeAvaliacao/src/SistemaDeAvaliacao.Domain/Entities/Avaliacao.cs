using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Entities
{
    public class Avaliacao
    {
        public int AvaliacaoId { get; set; }
        public Guid CodigoAcesso { get; set; }
        public string Objetivo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public string Curso { get; set; }
        public int TurmaId { get; set; }
        public string Professor { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Questao> Questoes { get; set; }
        public virtual ICollection<AvaliacaoResposta> Respostas { get; set; }
    }
}
