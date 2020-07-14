using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
   public  class AlunoAppService : AppServiceBase<Aluno>, IAlunoAppService
    {
        private readonly IAlunoService AlunoService;

        public AlunoAppService(IAlunoService serviceBase) : base(serviceBase)
        {
            AlunoService = serviceBase;
        }
    }
}
