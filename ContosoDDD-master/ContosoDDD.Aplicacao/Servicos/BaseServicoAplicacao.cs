using ContosoDDD.Aplicacao.Interfaces;
using ContosoDDD.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;

namespace ContosoDDD.Aplicacao.Servicos
{
    public abstract class BaseServicoAplicacao<T> : IDisposable, IBaseServicoAplicacao<T> where T : class
    {
        private readonly IBaseServicoDominio<T> _servicoDominio;

        public BaseServicoAplicacao(IBaseServicoDominio<T> servicoDominio)
        {
            _servicoDominio = servicoDominio;
        }

        public void Adicionar(T obj)
        {
            _servicoDominio.Adicionar(obj);
        }

        public void Atualizar(T obj)
        {
            _servicoDominio.Atualizar(obj);
        }

        public T DetalharId(int id)
        {
            return _servicoDominio.DetalharId(id);
        }

        public void Dispose()
        {
            _servicoDominio.Dispose();
        }

        public void Excluir(T obj)
        {
            _servicoDominio.Excluir(obj);
        }

        public IEnumerable<T> Listar()
        {
            return _servicoDominio.Listar();
        }
    }
}
