using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity FindById(int id);
        IEnumerable<TEntity> FindAll();
        TEntity Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        void Dispose();
    }
}
