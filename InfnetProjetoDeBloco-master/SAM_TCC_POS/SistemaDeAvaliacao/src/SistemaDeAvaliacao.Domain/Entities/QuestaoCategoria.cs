using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Entities
{
    public class QuestaoCategoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Questao> Questoes { get; set; }
    }
}