using CourseRating.Domain.Entities;
using System;

namespace CourseRating.Domain.Interfaces.Repositories
{
    public interface IQuestionarioRepository : IRepositoryBase<Questionario>, IDisposable
    {
    }
}