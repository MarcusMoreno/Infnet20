using SistemaDeAvaliacao.Domain.Entities;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IQuestaoService : IServiceBase<Questao>
    {
        bool QuestaoEstaSendoUsadaNumaAvaliacao(Questao questao);
    }
}
