using System;
using System.Collections.Generic;
using System.Linq;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SistemaDeAvaliacaoDbContext _db;

        public UsuarioRepository()
        {
            _db = new SistemaDeAvaliacaoDbContext();
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _db.Usuarios.ToList();
        }
        public void DesativarLock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}