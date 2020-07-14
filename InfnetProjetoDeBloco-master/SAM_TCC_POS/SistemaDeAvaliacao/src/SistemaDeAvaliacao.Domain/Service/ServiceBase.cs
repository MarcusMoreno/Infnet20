using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public TEntity Add(TEntity obj)
        {
            return _repositoryBase.Add(obj);
        }

        public TEntity FindById(int id)
        {
            return _repositoryBase.FindById(id);
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _repositoryBase.FindAll();
        }

        public TEntity Update(TEntity obj)
        {
            return _repositoryBase.Update(obj);
        }

        public void Remove(int id)
        {
            _repositoryBase.Remove(id);
        }

        public IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryBase.FindByPredicate(predicate);
        }

        public int SaveChanges()
        {
            return _repositoryBase.SaveChanges();
        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
