using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
    public  class ModuloService : ServiceBase<Modulo>, IModuloService
    {
        private readonly IModuloRepository ModuloRepository;

        public ModuloService(IModuloRepository repository) : base(repository)
        {
            ModuloRepository = repository;
        }
    }
}
