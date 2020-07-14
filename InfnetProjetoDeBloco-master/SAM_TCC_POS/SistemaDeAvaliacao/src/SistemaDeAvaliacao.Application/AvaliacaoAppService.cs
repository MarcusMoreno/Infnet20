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
    public class AvaliacaoAppService : ApplicationService, IAvaliacaoAppService
    {
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IQuestaoService _questaoService;

        public AvaliacaoAppService(IAvaliacaoService avaliacaoService, IQuestaoService questaoService, IUnitOfWork uow) : base(uow)
        {
            _avaliacaoService = avaliacaoService;
            _questaoService = questaoService;
        }

        public AvaliacaoViewModel ObterPorId(int id)
        {
            return Mapper.Map<Avaliacao, AvaliacaoViewModel>(_avaliacaoService.FindById(id));
        }

        public AvaliacaoViewModel ObterPorCodigoDeAcesso(Guid codigoDeAcesso)
        {
            return Mapper.Map<Avaliacao, AvaliacaoViewModel>(_avaliacaoService.FindByCodigoDeAcesso(codigoDeAcesso));
        }

        public IEnumerable<AvaliacaoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoViewModel>>(_avaliacaoService.FindAll());
        }

        public AvaliacaoViewModel Adicionar(AvaliacaoViewModel avaliacaoViewModel)
        {
            var ListaDeQuestoes = new List<Questao>();
            var CodigoAcesso = Guid.NewGuid();

            foreach (var i in avaliacaoViewModel.IdQuestoesSelecionadas)
            {
                ListaDeQuestoes.Add(_questaoService.FindById(i));
            }

            var avaliacao = Mapper.Map<AvaliacaoViewModel, Avaliacao>(avaliacaoViewModel);
            avaliacao.CodigoAcesso = CodigoAcesso;
            avaliacao.Questoes = ListaDeQuestoes;

            BeginTransaction();

            avaliacaoViewModel = Mapper.Map<Avaliacao, AvaliacaoViewModel>(_avaliacaoService.Add(avaliacao));

            Commit();

            return avaliacaoViewModel;
        }

        public AvaliacaoViewModel Atualizar(AvaliacaoViewModel avaliacaoViewModel)
        {
            if (AvaliacaoJaPossuiRepostas(avaliacaoViewModel.AvaliacaoId))
                throw new Exception("Não é permitdo editar avaliações que já tenham resposta.");

            if (AvaliacaoEstaAbertaParaRespostas(avaliacaoViewModel))
                throw new Exception("Não é permitido editar avaliações que estejam abertas para responder.");

            var avaliacao = Mapper.Map<AvaliacaoViewModel, Avaliacao>(avaliacaoViewModel);
            var ListaDeQuestoes = new List<Questao>();

            foreach (var i in avaliacaoViewModel.IdQuestoesSelecionadas)
            {
                ListaDeQuestoes.Add(_questaoService.FindById(i));
            }

            avaliacao.Questoes = ListaDeQuestoes;

            BeginTransaction();

            //_avaliacaoService.Update(avaliacao);
            _avaliacaoService.UpdateAvaliacaoQuestoes(avaliacao);

            Commit();

            return avaliacaoViewModel;
        }

        public void Remover(int id)
        {
            var avaliacao = ObterPorId(id);

            if (AvaliacaoJaPossuiRepostas(id))
                throw new Exception("Não é permitdo exclusão de avaliações que já tenham resposta.");

            if (AvaliacaoEstaAbertaParaRespostas(avaliacao))
                throw new Exception("Não é permitido exclusão de avaliações que estejam abertas para responder.");

            BeginTransaction();

            _avaliacaoService.Remove(id);

            Commit();
        }

        public bool AvaliacaoJaPossuiRepostas(int id)
        {
            return _avaliacaoService.AvaliacaoJaPossuiRespostas(id);
        }

        public bool AvaliacaoEstaAbertaParaRespostas(AvaliacaoViewModel avaliacaoViewModel)
        {
            var avaliacao = Mapper.Map<AvaliacaoViewModel, Avaliacao>(avaliacaoViewModel);
            return _avaliacaoService.AvaliacaoEstaAbertaParaRespostas(avaliacao);
        }

        public bool AlunoJaRespondeuAvaliacao(Guid codigoDeAcesso, int matricula)
        {
            return _avaliacaoService.AlunoJaRespondeuAvaliacao(codigoDeAcesso, matricula);
        }

        public void Dispose()
        {
            _avaliacaoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
