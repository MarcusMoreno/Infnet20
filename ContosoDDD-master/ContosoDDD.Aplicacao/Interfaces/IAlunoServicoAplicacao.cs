using ContosoDDD.Aplicacao.DTO;
using ContosoDDD.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoDDD.Aplicacao.Interfaces
{
    public interface IAlunoServicoAplicacao: IBaseServicoAplicacao<Aluno>
    {
        void Adicionar(AlunoDTO obj);
        AlunoDTO DetalharId(int id);
        IEnumerable<AlunoDTO> Listar();
        void Atualizar(AlunoDTO obj);
        void Excluir(AlunoDTO obj);
        void Dispose();
        Aluno DetalharPorNome(string busca);
        IEnumerable<AlunoDTO> ListarAlunosAtivos();
    }
}
