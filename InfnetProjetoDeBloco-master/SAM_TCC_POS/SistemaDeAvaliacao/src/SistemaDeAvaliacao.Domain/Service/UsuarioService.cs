using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario ObterPorId(string id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos().ToList();
        }

        public void DesativarLock(string id)
        {
            _usuarioRepository.DesativarLock(id);
        }


    }
}
