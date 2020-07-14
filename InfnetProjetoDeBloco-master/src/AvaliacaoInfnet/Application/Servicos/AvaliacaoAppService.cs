using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Application
{
    public class AvaliacaoAppService : AppServiceBase<Avaliacao>, IAvaliacaoAppService
    {
        private readonly IAvaliacaoService AvaliacaoService;

        public AvaliacaoAppService(IAvaliacaoService serviceBase) : base(serviceBase)
        {
            AvaliacaoService = serviceBase;
        }
    }
}
