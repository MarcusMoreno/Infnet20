using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
   public class CursoService : ServiceBase<Curso>, ICursoService
    {
        private readonly ICursoRepository CursoRepository;

        public CursoService(ICursoRepository repository) : base(repository)
        {
            CursoRepository = repository;
        }
    }
}
