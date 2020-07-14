using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {

        protected SistemaDeAvaliacaoDbContext Db;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(SistemaDeAvaliacaoDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity obj)
        {
            return DbSet.Add(obj);
        }

        public virtual TEntity FindById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public IEnumerable<TEntity> FindByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
