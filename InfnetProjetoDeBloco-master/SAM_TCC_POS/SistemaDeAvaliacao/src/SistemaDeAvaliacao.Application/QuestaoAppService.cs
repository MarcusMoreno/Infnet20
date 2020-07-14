using AutoMapper;
using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Service;
using SistemaDeAvaliacao.Infra.Data.Interface;
using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application
{
    public class QuestaoAppService : ApplicationService, IQuestaoAppService
    {
        private readonly IQuestaoService _questaoService;

        public QuestaoAppService(IQuestaoService questaoService, IUnitOfWork uow) : base(uow)
        {
            _questaoService = questaoService;
        }

        public QuestaoViewModel ObterPorId(int id)
        {
            return Mapper.Map<Questao, QuestaoViewModel>(_questaoService.FindById(id));
        }

        public IEnumerable<QuestaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Questao>, IEnumerable<QuestaoViewModel>>(_questaoService.FindAll());
        }

        public QuestaoViewModel Adicionar(QuestaoViewModel questaoViewModel)
        {
            var questao = Mapper.Map<QuestaoViewModel, Questao>(questaoViewModel);

            BeginTransaction();

            questaoViewModel = Mapper.Map<Questao, QuestaoViewModel>(_questaoService.Add(questao));

            Commit();

            return questaoViewModel;
        }

        public QuestaoViewModel Atualizar(QuestaoViewModel questaoViewModel)
        {

            if (QuestaoEstaSendoUsadaNumaAvaliacao(questaoViewModel))
                throw new Exception("Não é possível atualizar questões associadas a avaliações existentes.");

            var questao = Mapper.Map<QuestaoViewModel, Questao>(questaoViewModel);

            BeginTransaction();

            _questaoService.Update(questao);

            Commit();

            return questaoViewModel;
        }

        public void Remover(int id)
        {
            var questao = ObterPorId(id);

            if (QuestaoEstaSendoUsadaNumaAvaliacao(questao))
                throw new Exception("Não é possível apagar questões associadas a avaliações existentes.");

            BeginTransaction();

            _questaoService.Remove(id);

            Commit();
        }

        public bool QuestaoEstaSendoUsadaNumaAvaliacao(QuestaoViewModel questaoViewModel)
        {
            var questao = Mapper.Map<QuestaoViewModel, Questao>(questaoViewModel);
            return _questaoService.QuestaoEstaSendoUsadaNumaAvaliacao(questao);
        }

        public void Dispose()
        {
            _questaoService.Dispose();
        }
    }
}
