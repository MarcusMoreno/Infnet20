using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoDDD.Dominio.Interfaces.Servicos
{
    public interface IBaseServicoDominio<T> where T : class
    {
        void Adicionar(T obj);

        T DetalharId(int id);

        IEnumerable<T> Listar();

        void Atualizar(T obj);

        void Excluir(T obj);

        void Dispose();
    }
}
