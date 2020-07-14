using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoInfnet.Persistencia.Repository
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        private readonly AvaliacaoInfnetContext _contexto;

        public RepositoryBase(AvaliacaoInfnetContext avaliacaoInfnetContext)
        {
            this._contexto = avaliacaoInfnetContext;
        }

        public void Add(T obj)
        {
            try
            {
                _contexto.Set<T>().Add(obj);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _contexto.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _contexto.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            try
            {
                _contexto.Set<T>().Remove(obj);
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(T obj)
        {
            try
            {
                _contexto.Entry(obj).State = EntityState.Modified;
                _contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
