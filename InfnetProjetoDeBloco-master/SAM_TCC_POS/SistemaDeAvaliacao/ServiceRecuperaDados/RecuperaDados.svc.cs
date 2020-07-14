using System;
using System.Collections.Generic;

namespace ServiceRecuperaDados
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RecuperaDados : IRecuperaDados
    {
        private static List<Curso> _cursos;
        private static List<Turma> _turmas;
        private static List<Aluno> _alunos;
        private static List<Professor> _professores;
        private static List<Modulo> _modulos;
        private static List<Bloco> _blocos;

        public RecuperaDados()
        {
            PopulaDados dados = new PopulaDados();
            _cursos = dados.Cursos();
            _professores = dados.Professores();
            _blocos = dados.Blocos();
            _modulos = dados.Modulos();
            _turmas = dados.Turmas();
            _alunos = dados.Alunos();
            
        }
        //adicionar
        public void adicionaCurso(Curso curso)
        {
            _cursos.Add(curso);
        }
        public void adicionaTurma(Turma turma)
        {
            _turmas.Add(turma);
        }
        public void adicionaAluno(Aluno aluno)
        {
            _alunos.Add(aluno);
        }
        public void adicionaProfessor(Professor professor)
        {
            _professores.Add(professor);
        }

        //apagar
        public void apagarAlunos()
        {
            _alunos.Clear();
        }
        public void apagarProfessores()
        {
            _professores.Clear();
        }
        public void apagarTurmas()
        {
            _turmas.Clear();
        }
        public void apagarCursos()
        {
            _cursos.Clear();
        }

        //recuperar
        public List<Curso> RecuperaCursos()
        {
            return _cursos;
        }
        public List<Turma> RecuperaTurmas()
        {
            return _turmas;
        }
        public List<Professor> RecuperaProfessores()
        {
            return _professores;
        }
        public List<Aluno> RecuperaAlunos()
        {
            return _alunos;
        }
        public List<Modulo> RecuperaModulos()
        {
            return _modulos;
        }
        public List<Aluno> ListaDeAlunosDaTurma(Turma turma) 
        {
            List<Aluno> alunos = new List<Aluno>();
            foreach (var a in _alunos)
            {
                if (a.turma.nomeTurma.Equals(turma.nomeTurma))
                {
                    alunos.Add(a);
                }
            }
            return alunos;
        }

        public List<Aluno> ListaDeAlunosDaTurmaPorNome(String turma)
        {
            List<Aluno> alunos = new List<Aluno>();
            foreach (var a in _alunos)
            {
                if (a.turma.nomeTurma.ToLower().Contains(turma.ToLower()))
                {
                    alunos.Add(a);
                }
            }
            return alunos;
        }

        public List<Turma> ListaDeTurmasDoCurso(Curso curso)
        {
            List<Turma> turmas = new List<Turma>();
            foreach(var t in _turmas)
            {
                if (t.modulo.bloco.curso.nomeCurso.Equals(curso.nomeCurso))
                {
                    turmas.Add(t);
                }
            }
            return turmas;
        }

        public Turma turmaPorID(int id)
        {
            foreach(var t in _turmas)
            {
                if (t.idTurma.Equals(id))
                {
                    return t;
                }
            }
            return null;
        }

        public Turma turmaPorNome(string nome)
        {
            foreach (var t in _turmas)
            {
                if (t.nomeTurma.ToLower().Contains(nome.ToLower()))
                {
                    return t;
                }
            }
            return null;
        }

        public Aluno alunoPorId(int id)
        {
            foreach(var a in _alunos)
            {
                if (a.idAluno.Equals(id))
                {
                    return a;
                }
            }
            return null;
        }

        public Aluno alunoPorNome(string nome)
        {
            foreach(var a in _alunos)
            {
                if (a.nomeAluno.ToLower().Contains(nome.ToLower()))
                {
                    return a;
                }
            }
            return null;
        }
    }
}
