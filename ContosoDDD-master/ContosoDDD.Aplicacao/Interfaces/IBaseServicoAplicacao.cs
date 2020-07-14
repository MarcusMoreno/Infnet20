using System.Collections.Generic;

namespace ContosoDDD.Aplicacao.Interfaces
{
    public interface IBaseServicoAplicacao<T> where T : class
    {
        void Adicionar(T obj);

        T DetalharId(int id);

        IEnumerable<T> Listar();

        void Atualizar(T obj);

        void Excluir(T obj);

        void Dispose();
    }
}
