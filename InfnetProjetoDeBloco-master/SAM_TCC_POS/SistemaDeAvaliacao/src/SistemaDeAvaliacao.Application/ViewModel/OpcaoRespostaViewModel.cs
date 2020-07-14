using SistemaDeAvaliacao.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class OpcaoRespostaViewModel
    {
        public int OpcaoRespostaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<AvaliacaoResposta> AvaliacaoRespostas { get; set; }
    }
}
