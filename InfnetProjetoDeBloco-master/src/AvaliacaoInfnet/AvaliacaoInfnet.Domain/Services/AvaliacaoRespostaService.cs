using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class AvaliacaoRespostaService : ServiceBase<AvaliacaoResposta>, IAvaliacaoRespostaService
    {
        private readonly IAvaliacaoRespostaRepository AvaliacaoRespostaRepository;

        public AvaliacaoRespostaService(IAvaliacaoRespostaRepository repository) : base(repository)
        {
            AvaliacaoRespostaRepository = repository;
        }
    }
}
