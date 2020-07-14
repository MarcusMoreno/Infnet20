using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class EntrevistadoService : ServiceBase<Entrevistado>, IEntrevistadoService
    {
        private readonly IEntrevistadoRepository EntrevistadoRepository;

        public EntrevistadoService(IEntrevistadoRepository repository) : base(repository)
        {
            EntrevistadoRepository = repository;
        }
    }
}
