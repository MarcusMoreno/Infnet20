using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Application
{
    public class TipoRespostaAppService : AppServiceBase<TipoResposta>, ITipoRespostaAppService
    {
        private readonly ITipoRespostaService TipoRespostaService;

        public TipoRespostaAppService(ITipoRespostaService serviceBase) : base(serviceBase)
        {
            TipoRespostaService = serviceBase;
        }
    }
}
