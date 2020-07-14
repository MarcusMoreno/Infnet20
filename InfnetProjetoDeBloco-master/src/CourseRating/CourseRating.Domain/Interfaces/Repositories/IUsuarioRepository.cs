using CourseRating.Domain.Entities;
using System;

namespace CourseRating.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>, IDisposable
    {
    }
}
