using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System;
using System.Linq;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class AvaliacaoService : ServiceBase<Avaliacao>, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;
        private readonly IAvaliacaoRespostaRepository _avaliacaoRespostaRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository, IAvaliacaoRespostaRepository avaliacaoRespostaRepository) : base(avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
            _avaliacaoRespostaRepository = avaliacaoRespostaRepository;
        }

        public Avaliacao UpdateAvaliacaoQuestoes(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.UpdateAvaliacaoQuestoes(avaliacao);
        }

        public Avaliacao FindByCodigoDeAcesso(Guid codigoDeAcesso)
        {
            return _avaliacaoRepository.FindByCodigoDeAcesso(codigoDeAcesso);
        }

        public bool AvaliacaoJaPossuiRespostas(int avaliacaoId)
        {
            var resposta = _avaliacaoRespostaRepository.FindAll().Where(r => r.Avaliacao.AvaliacaoId == avaliacaoId).FirstOrDefault();

            if (resposta != null)
                return true;

            return false;
        }

        public bool AvaliacaoEstaAbertaParaRespostas(Avaliacao avaliacao)
        {
            var hoje = DateTime.Now;

            if (avaliacao.DataInicio < hoje && avaliacao.DataTermino > hoje)
                return true;

            return false;
        }

        public bool AlunoJaRespondeuAvaliacao(Guid codigoDeAcesso, int matricula)
        {
            var avaliacao = FindByCodigoDeAcesso(codigoDeAcesso).Respostas.Where(r => r.MatriculaAluno == matricula).FirstOrDefault();

            if (avaliacao != null)
                return true;

            return false;
        }
    }
}
