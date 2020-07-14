using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
    public class CursoAppService : AppServiceBase<Curso>, ICursoAppService
    {
        private readonly ICursoService CursoService;

        public CursoAppService(ICursoService serviceBase) : base(serviceBase)
        {
            CursoService = serviceBase;
        }
    }
}
