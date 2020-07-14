using SistemaDeAvaliacao.Infra.Data.Context;
using SistemaDeAvaliacao.Infra.Data.Interface;
using System;

namespace SistemaDeAvaliacao.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SistemaDeAvaliacaoDbContext _context;
        private bool _disposed;

        public UnitOfWork(SistemaDeAvaliacaoDbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
