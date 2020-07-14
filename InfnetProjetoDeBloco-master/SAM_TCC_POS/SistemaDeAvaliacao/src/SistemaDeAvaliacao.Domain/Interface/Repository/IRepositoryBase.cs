using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaDeAvaliacao.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
        TEntity Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
