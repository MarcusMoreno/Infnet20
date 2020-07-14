using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository UsuarioRepository;

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            UsuarioRepository = repository;
        }
    }
}
