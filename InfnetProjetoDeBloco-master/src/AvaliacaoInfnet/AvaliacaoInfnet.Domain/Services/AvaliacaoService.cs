using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class AvaliacaoService : ServiceBase<Avaliacao>, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository AvaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository repository) : base(repository)
        {
            AvaliacaoRepository = repository;
        }
    }
}
