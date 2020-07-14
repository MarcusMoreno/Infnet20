using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
    public  class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository AlunoRepository;

        public AlunoService(IAlunoRepository repository) : base(repository)
        {
            AlunoRepository = repository;
        }
    }
}
