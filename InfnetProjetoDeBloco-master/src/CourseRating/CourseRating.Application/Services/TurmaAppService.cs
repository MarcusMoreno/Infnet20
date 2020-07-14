using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
    public class TurmaAppService : AppServiceBase<Turma>, ITurmaAppService
    {
        private readonly ITurmaService TurmaService;

        public TurmaAppService(ITurmaService serviceBase) : base(serviceBase)
        {
            TurmaService = serviceBase;
        }
    }
}
