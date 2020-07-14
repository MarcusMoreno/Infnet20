using SistemaDeAvaliacao.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Interface.Repository
{
    public interface IAvaliacaoRespostaRepository : IRepositoryBase<AvaliacaoResposta>
    {
        bool Add(IEnumerable<AvaliacaoResposta> avaliacaoRespostas);
    }
}
