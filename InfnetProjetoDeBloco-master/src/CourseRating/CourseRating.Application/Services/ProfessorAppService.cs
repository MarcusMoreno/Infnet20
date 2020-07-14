using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
    public class ProfessorAppService : AppServiceBase<Professor>, IProfessorAppService
    {
        private readonly IProfessorService ProfessorService;

        public ProfessorAppService(IProfessorService serviceBase) : base(serviceBase)
        {
            ProfessorService = serviceBase;
        }
    }
}