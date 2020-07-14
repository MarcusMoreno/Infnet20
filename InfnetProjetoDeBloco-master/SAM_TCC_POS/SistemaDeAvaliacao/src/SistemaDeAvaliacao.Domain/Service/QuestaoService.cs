using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System.Linq;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class QuestaoService : ServiceBase<Questao>, IQuestaoService
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public QuestaoService(IQuestaoRepository questaoRepository, IAvaliacaoRepository avaliacaoRepository) : base(questaoRepository)
        {
            _questaoRepository = questaoRepository;
            _avaliacaoRepository = avaliacaoRepository;
        }

        public bool QuestaoEstaSendoUsadaNumaAvaliacao(Questao questao)
        {
            var avaliacoes = _avaliacaoRepository.FindAll().Where(a => a.Questoes.Any(q => q.QuestaoId == questao.QuestaoId)).ToList();
            
            if (avaliacoes.Count > 0)
                return true;

            return false;
        }
    }
}
