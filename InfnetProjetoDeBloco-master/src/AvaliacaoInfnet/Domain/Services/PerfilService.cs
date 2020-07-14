using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Domain.Services
{
    public class PerfilService : ServiceBase<Perfil>, IPerfilService
    {
        private readonly IPerfilRepository PerfilRepository;

        public PerfilService(IPerfilRepository repository) : base(repository)
        {
            PerfilRepository = repository;
        }
    }
}
