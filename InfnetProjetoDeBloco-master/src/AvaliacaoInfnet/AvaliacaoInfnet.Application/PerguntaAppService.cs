using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Application
{
    public class PerguntaAppService : AppServiceBase<Pergunta>, IPerguntaAppService
    {
        private readonly IPerguntaService PerguntaService;

        public PerguntaAppService(IPerguntaService serviceBase) : base(serviceBase)
        {
            PerguntaService = serviceBase;
        }
    }
}
