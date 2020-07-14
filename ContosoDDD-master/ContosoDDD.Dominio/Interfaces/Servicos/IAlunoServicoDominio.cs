using ContosoDDD.Dominio.Entidade;
using System.Collections.Generic;

namespace ContosoDDD.Dominio.Interfaces.Servicos
{
    public interface IAlunoServicoDominio: IBaseServicoDominio<Aluno>
    {
        Aluno DetalharPorNome(string busca);
        IEnumerable<Aluno> ListarAlunosAtivos();
    }
}
