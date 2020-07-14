using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class PerguntaService : ServiceBase<Pergunta>, IPerguntaService
    {
        private readonly IPerguntaRepository PerguntaRepository;

        public PerguntaService(IPerguntaRepository repository) : base(repository)
        {
            PerguntaRepository = repository;
        }
    }
}
