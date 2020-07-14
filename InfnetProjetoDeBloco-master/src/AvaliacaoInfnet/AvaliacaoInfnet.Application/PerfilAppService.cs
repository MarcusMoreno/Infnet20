using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Application
{
    public class PerfilAppService : AppServiceBase<Perfil>, IPerfilAppService
    {
        private readonly IPerfilService PerfilService;

        public PerfilAppService(IPerfilService serviceBase) : base(serviceBase)
        {
            PerfilService = serviceBase;
        }
    }
}
