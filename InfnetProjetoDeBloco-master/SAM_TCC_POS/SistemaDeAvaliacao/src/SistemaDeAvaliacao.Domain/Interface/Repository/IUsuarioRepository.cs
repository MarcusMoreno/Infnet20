using System;
using System.Collections.Generic;
using SistemaDeAvaliacao.Domain.Entities;

namespace SistemaDeAvaliacao.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}