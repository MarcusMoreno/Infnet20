using SistemaDeAvaliacao.Domain.Entities;
using System;

namespace SistemaDeAvaliacao.Domain.Interface.Repository
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>
    {
        Avaliacao UpdateAvaliacaoQuestoes(Avaliacao avaliacao);
        Avaliacao FindByCodigoDeAcesso(Guid codigoDeAcesso);
    }
}
