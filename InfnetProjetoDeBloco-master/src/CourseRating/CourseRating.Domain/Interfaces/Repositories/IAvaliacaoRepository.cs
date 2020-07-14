using CourseRating.Domain.Entities;
using System;

namespace CourseRating.Domain.Interfaces.Repositories
{
    public interface IAvaliacaoRepository : IRepositoryBase<Avaliacao>, IDisposable
    {
    }
}
