using SistemaDeAvaliacao.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application.Interface
{
    public interface IQuestaoAppService : IDisposable
    {
        QuestaoViewModel ObterPorId(int id);
        IEnumerable<QuestaoViewModel> ObterTodos();
        QuestaoViewModel Adicionar(QuestaoViewModel questaoViewModel);
        QuestaoViewModel Atualizar(QuestaoViewModel questaoViewModel);
        void Remover(int id);
    }
}
