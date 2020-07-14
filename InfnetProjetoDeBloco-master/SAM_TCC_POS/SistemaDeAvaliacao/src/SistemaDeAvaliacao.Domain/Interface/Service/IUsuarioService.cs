using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeAvaliacao.Domain.Interface.Service
{
    public interface IUsuarioService
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
