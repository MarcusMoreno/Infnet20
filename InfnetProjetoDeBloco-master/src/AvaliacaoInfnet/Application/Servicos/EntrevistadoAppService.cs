using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;

namespace AvaliacaoInfnet.Application
{
    public class EntrevistadoAppService : AppServiceBase<Entrevistado>, IEntrevistadoAppService
    {
        private readonly IEntrevistadoService EntrevistadoService;

        public EntrevistadoAppService(IEntrevistadoService serviceBase) : base(serviceBase)
        {
            EntrevistadoService = serviceBase;
        }
    }
}
