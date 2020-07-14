using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
    public class TurmaService : ServiceBase<Turma>, ITurmaService
    {
        private readonly ITurmaRepository TurmaRepository;

        public TurmaService(ITurmaRepository repository) : base(repository)
        {
            TurmaRepository = repository;
        }
    }
}
