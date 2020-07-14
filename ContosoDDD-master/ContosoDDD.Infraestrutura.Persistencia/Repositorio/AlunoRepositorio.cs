using ContosoDDD.Dominio.Entidade;
using ContosoDDD.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContosoDDD.Infraestrutura.Persistencia.Repositorio
{
    public class AlunoRepositorio : BaseRepositorio<Aluno>, IAlunoRepositorio
    {
        public ContosoDbContext _contexto;

        public AlunoRepositorio(ContosoDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Aluno DetalharPorNome(string busca)
        {
            return _contexto.Alunos.FirstOrDefault(a => (a.Nome +" "+ a.Sobrenome).Contains(busca));
        }

        public IEnumerable<Aluno> ListarAlunosAtivos()
        {
            return _contexto.Alunos.Where(a => a.AlunoAtivo()).ToList();
        }
    }
}
