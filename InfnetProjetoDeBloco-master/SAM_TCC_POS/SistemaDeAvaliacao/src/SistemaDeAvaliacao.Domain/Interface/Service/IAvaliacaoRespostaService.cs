using SistemaDeAvaliacao.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IAvaliacaoRespostaService
    {
        bool Add(IEnumerable<AvaliacaoResposta> avaliacaoRespostas);
    }
}
