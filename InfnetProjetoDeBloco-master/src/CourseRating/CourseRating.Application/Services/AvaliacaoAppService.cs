using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
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
