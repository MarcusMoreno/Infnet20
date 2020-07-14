using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class AvaliacaoRespostaService : ServiceBase<AvaliacaoResposta>, IAvaliacaoRespostaService
    {
        private readonly IAvaliacaoRespostaRepository _avaliacaoRespostaRepository;

        public AvaliacaoRespostaService(IAvaliacaoRespostaRepository avaliacaoRespostaRepository) : base(avaliacaoRespostaRepository)
        {
            _avaliacaoRespostaRepository = avaliacaoRespostaRepository;
        }

        public bool Add(IEnumerable<AvaliacaoResposta> avaliacaoRespostas)
        {
            return _avaliacaoRespostaRepository.Add(avaliacaoRespostas);
        }
    }
}
