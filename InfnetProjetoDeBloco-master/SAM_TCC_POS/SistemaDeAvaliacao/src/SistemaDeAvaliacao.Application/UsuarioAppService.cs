using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAvaliacao.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario ObterPorId(string id)
        {
            return _usuarioService.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioService.ObterTodos().ToList();
        }

        public void DesativarLock(string id)
        {
            _usuarioService.DesativarLock(id);
        }
    }
}
