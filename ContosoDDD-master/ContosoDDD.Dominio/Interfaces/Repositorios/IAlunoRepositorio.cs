using ContosoDDD.Dominio.Entidade;
using System.Collections.Generic;

namespace ContosoDDD.Dominio.Interfaces.Repositorios
{
    public interface IAlunoRepositorio : IBaseRepositorio<Aluno>
    {
        Aluno DetalharPorNome(string busca);
        IEnumerable<Aluno> ListarAlunosAtivos();
    }
}
