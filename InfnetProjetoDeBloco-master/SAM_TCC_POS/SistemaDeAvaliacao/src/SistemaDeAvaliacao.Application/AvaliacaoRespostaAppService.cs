using AutoMapper;
using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Service;
using SistemaDeAvaliacao.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAvaliacao.Application
{
    public class AvaliacaoRespostaAppService : ApplicationService, IAvaliacaoRespostaAppService
    {
        private readonly IAvaliacaoRespostaService _avaliacaoRespostaService;
        private readonly IAvaliacaoService _avaliacaoService;
        private readonly IOpcaoRespostaService _opcaoRespostaService;

        public AvaliacaoRespostaAppService(IAvaliacaoRespostaService avaliacaoRespostaService, IAvaliacaoService avaliacaoService, IOpcaoRespostaService opcaoRespostaService, IUnitOfWork uow) : base(uow)
        {
            _avaliacaoRespostaService = avaliacaoRespostaService;
            _avaliacaoService = avaliacaoService;
            _opcaoRespostaService = opcaoRespostaService;
        }

        public ResponderAvaliacaoViewModel MontarResponderAvaliacaoViewModel(Guid codigoDeAcesso, int matricula)
        {
            var Avaliacao = Mapper.Map<Avaliacao, AvaliacaoViewModel>(_avaliacaoService.FindByCodigoDeAcesso(codigoDeAcesso));
            var AvaliacaoQuestoes = Mapper.Map<IEnumerable<Questao>, IEnumerable<QuestaoViewModel>>(Avaliacao.Questoes);
            var OpcoesResposta = Mapper.Map<IEnumerable<OpcaoResposta>, IEnumerable<OpcaoRespostaViewModel>>(_opcaoRespostaService.FindAll());

            List<AvaliacaoRespostaViewModel> AvaliacaoRespostaCollection = new List<AvaliacaoRespostaViewModel>();

            foreach (var item in AvaliacaoQuestoes)
            {
                var AvaliacaoResposta = new AvaliacaoRespostaViewModel
                {
                    QuestaoId = item.QuestaoId
                };

                AvaliacaoRespostaCollection.Add(AvaliacaoResposta);
            }

            var ResponderAvaliacaoViewModel = new ResponderAvaliacaoViewModel()
            {
                AvaliacaoId = Avaliacao.AvaliacaoId,
                CodigoAcesso = Avaliacao.CodigoAcesso,
                MatriculaAluno = matricula,
                NomeAluno = "Rodrigo Clemente",

                //Avaliacao
                Objetivo = Avaliacao.Objetivo,
                DataInicio = Avaliacao.DataInicio,
                DataTermino = Avaliacao.DataTermino,
                Curso = Avaliacao.Curso,
                TurmaId = Avaliacao.TurmaId,
                Professor = Avaliacao.Professor,

                //Colecoes
                Questoes = AvaliacaoQuestoes.ToList(),
                OpcoesResposta = OpcoesResposta.ToList(),
                AvaliacaoRespostas = AvaliacaoRespostaCollection
            };
            return ResponderAvaliacaoViewModel;
        }

        public bool Adicionar(ResponderAvaliacaoViewModel respostas)
        {
            var AvaliacaoRespostaCollection = new List<AvaliacaoResposta>();
            var AvaliacaoRespostas = new AvaliacaoResposta();

            foreach (var r in respostas.AvaliacaoRespostas)
            {
                AvaliacaoRespostas = Mapper.Map<ResponderAvaliacaoViewModel, AvaliacaoResposta>(respostas);
                AvaliacaoRespostas.QuestaoId = r.QuestaoId;
                AvaliacaoRespostas.Resposta = r.Resposta;
                AvaliacaoRespostaCollection.Add(AvaliacaoRespostas);
            }

            BeginTransaction();

            if (!_avaliacaoRespostaService.Add(AvaliacaoRespostaCollection))
                return false;

            Commit();

            return true;
        }

        public bool AvaliacaoEstaAbertaParaRespostas(AvaliacaoViewModel avaliacaoViewModel)
        {
            var avaliacao = Mapper.Map<AvaliacaoViewModel, Avaliacao>(avaliacaoViewModel);

            return _avaliacaoService.AvaliacaoEstaAbertaParaRespostas(avaliacao);
        }
    }
}
