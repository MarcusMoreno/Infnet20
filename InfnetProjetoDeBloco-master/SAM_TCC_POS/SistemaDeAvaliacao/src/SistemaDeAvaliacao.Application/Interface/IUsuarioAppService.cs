using SistemaDeAvaliacao.Domain.Entities;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application.Interface
{
    public interface IUsuarioAppService
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}
