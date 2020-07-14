using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
    public  class QuestionarioService : ServiceBase<Questionario>, IQuestionarioService
    {
        private readonly IQuestionarioRepository QuestionarioRepository;

        public QuestionarioService(IQuestionarioRepository repository) : base(repository)
        {
            QuestionarioRepository = repository;
        }
    }
}
