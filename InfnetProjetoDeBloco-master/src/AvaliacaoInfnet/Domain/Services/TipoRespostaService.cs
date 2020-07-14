using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class TipoRespostaService : ServiceBase<TipoResposta>, ITipoRespostaService
    {
        private readonly ITipoRespostaRepository TipoRespostaRepository;

        public TipoRespostaService(ITipoRespostaRepository repository) : base(repository)
        {
            TipoRespostaRepository = repository;
        }
    }
}
