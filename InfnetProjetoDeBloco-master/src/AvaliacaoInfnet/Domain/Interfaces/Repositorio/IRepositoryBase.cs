using System;
using System.Collections.Generic;

namespace AvaliacaoInfnet.Domain.Interfaces.Repositorio
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

    }
}
