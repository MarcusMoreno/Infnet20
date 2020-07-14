using SistemaDeAvaliacao.Domain.Entities;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IQuestaoCategoriaService : IServiceBase<QuestaoCategoria>
    {
        bool CategoriaPossuiQuestoes(QuestaoCategoria questaoCategoria);
    }
}
