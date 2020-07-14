using CourseRating.Domain.Entities;
using System;

namespace CourseRating.Domain.Interfaces.Repositories
{
    public interface IProfessorRepository : IRepositoryBase<Professor>, IDisposable
    {
    }
}
