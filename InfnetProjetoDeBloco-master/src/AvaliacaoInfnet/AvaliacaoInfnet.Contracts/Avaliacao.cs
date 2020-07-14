using System;

namespace AvaliacaoInfnet.Contracts
{
    public class Avaliacao
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Titulo { get; set; }

        public bool Status { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }


        //TODO relacionamentos
    }
}
