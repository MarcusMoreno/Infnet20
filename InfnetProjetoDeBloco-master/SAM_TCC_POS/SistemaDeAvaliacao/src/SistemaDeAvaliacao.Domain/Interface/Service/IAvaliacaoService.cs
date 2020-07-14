using SistemaDeAvaliacao.Domain.Entities;
using System;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IAvaliacaoService : IServiceBase<Avaliacao>
    {
        Avaliacao UpdateAvaliacaoQuestoes(Avaliacao avaliacao);
        Avaliacao FindByCodigoDeAcesso(Guid codigoDeAcesso);
        bool AvaliacaoJaPossuiRespostas(int avaliacaoId);
        bool AvaliacaoEstaAbertaParaRespostas(Avaliacao avaliacao);
        bool AlunoJaRespondeuAvaliacao(Guid codigoDeAcesso, int matricula);
    }
}
