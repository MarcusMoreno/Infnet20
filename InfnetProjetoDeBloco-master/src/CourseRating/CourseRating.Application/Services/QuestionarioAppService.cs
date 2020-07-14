using CourseRating.Application.Interface;
using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Application.Services
{
    public  class QuestionarioAppService : AppServiceBase<Questionario>, IQuestionarioAppService
    {
        private readonly IQuestionarioService QuestionarioService;

        public QuestionarioAppService(IQuestionarioService serviceBase) : base(serviceBase)
        {
            QuestionarioService = serviceBase;
        }
    }
}
