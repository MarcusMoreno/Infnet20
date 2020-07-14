using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceRecuperaDados
{
    public class PopulaDados
    {
        private static List<Curso> _cursos;
        private static List<Turma> _turmas;
        private static List<Aluno> _alunos;
        private static List<Professor> _professores;
        private static List<Modulo> _modulos;
        private static List<Bloco> _blocos;

        //FAZER NO WCF
        public PopulaDados()
        {
            _cursos = new List<Curso>();
            _turmas = new List<Turma>();
            _alunos = new List<Aluno>();
            _professores = new List<Professor>();
            _modulos = new List<Modulo>();
            _blocos = new List<Bloco>();

            Professor aquino = new Professor()
            {
                idProfessor = Guid.NewGuid(),
                nomeProfessor = "Aquino Botelho",
                titulo = 'A',
                dataAdmissao = DateTime.Parse("12/12/1991"),
                email = "aquino.botelho@infnet.edu.br"
            };
            _professores.Add(aquino);

            Professor pivotto = new Professor()
            {
                idProfessor = Guid.NewGuid(),
                nomeProfessor = "Carlos Pivotto",
                email = "pivotto@gmail.com",
                titulo = 'B',
                dataAdmissao = DateTime.Parse("02/02/2007")
            };
            _professores.Add(pivotto);

            Professor leonardo = new Professor()
            {
                idProfessor = Guid.NewGuid(),
                nomeProfessor = "Leonardo Nascimento",
                email = "leonardo.nascimento@infnet.edu.br",
                titulo = 'A',
                dataAdmissao = DateTime.Parse("11/01/1999")
            };
            _professores.Add(leonardo);

            Curso MES = new Curso()
            {
                idCurso = Guid.NewGuid(),
                nomeCurso = "MIT Eng Softw"
            };
            _cursos.Add(MES);

            Curso MBD = new Curso()
            {
                idCurso = Guid.NewGuid(),
                nomeCurso = "MBA BigData"
            };
            _cursos.Add(MBD);

            Bloco B1 = new Bloco()
            {
                idBloco = Guid.NewGuid(),
                nomeBloco = "Engenharia de Software e Metricas",
                curso = MES
            };
            _blocos.Add(B1);
            Modulo engSoft = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Engenharia de Software",
                bloco = B1
            };
            Modulo metricas = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Metricas",
                bloco = B1
            };
            _modulos.Add(engSoft);
            _modulos.Add(metricas);

            Bloco B2 = new Bloco()
            {
                idBloco = Guid.NewGuid(),
                nomeBloco = "Processos Ageis e Modelagem",
                curso = MES
            };
            _blocos.Add(B2);
            Modulo ageis = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Processos Ageis",
                bloco = B2
            };
            Modulo modelagem = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Modelagem",
                bloco = B2
            };
            _modulos.Add(ageis);
            _modulos.Add(modelagem);

            Bloco B3 = new Bloco()
            {
                idBloco = Guid.NewGuid(),
                nomeBloco = "Tecnologia .NET com C#",
                curso = MES
            };
            _blocos.Add(B3);
            Modulo dotNet = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Tecnologia .Net com C#",
                bloco = B3
            };
            Modulo persistencia = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Persistencia com .NET",
                bloco = B3
            };
            _modulos.Add(dotNet);
            _modulos.Add(persistencia);

            Bloco B4 = new Bloco()
            {
                idBloco = Guid.NewGuid(),
                nomeBloco = "Aplicacoes WEB e servicos",
                curso = MES
            };
            _blocos.Add(B4);
            Modulo apWeb = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Aplicacoes WEB",
                bloco = B4
            };
            Modulo servicos = new Modulo()
            {
                idModulo = Guid.NewGuid(),
                nomeModulo = "Servicos com WCF",
                bloco = B4
            };
            _modulos.Add(apWeb);
            _modulos.Add(servicos);


            Turma terca = new Turma()
            {
                idTurma = Guid.NewGuid(),
                nomeTurma = "terca noite",
                modulo = apWeb,
                professor = pivotto
            };
            _turmas.Add(terca);

            Turma sabado = new Turma()
            {
                idTurma = Guid.NewGuid(),
                nomeTurma = "sabado integral",
                modulo = metricas,
                professor = aquino
            };
            _turmas.Add(sabado);


            Aluno a1 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Rodrigo Clemente",
                emailAluno = "rodrigom.clemente@hotmail.com",
                turma = terca
            };
            Aluno a2 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Marcus Moreno",
                emailAluno = "moreno.mvv@gmail.com",
                turma = terca
            };
            Aluno a3 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Gabriel Felipe",
                emailAluno = "gf_rock21@hotmail.com",
                turma = terca
            };
            _alunos.Add(a1);
            _alunos.Add(a2);
            _alunos.Add(a3);

            Aluno s1 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Enzo Nogueira",
                emailAluno = "enzopagodeiro@gmail.com",
                turma = sabado
            };
            Aluno s2 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Enzo Pagodinho",
                emailAluno = "enzoxerem@gmail.com",
                turma = sabado
            };
            Aluno s3 = new Aluno()
            {
                idAluno = Guid.NewGuid(),
                nomeAluno = "Enzo Leonardo",
                emailAluno = "garotozonasul@gmail.com",
                turma = sabado
            };
            _alunos.Add(s1);
            _alunos.Add(s2);
            _alunos.Add(s3);

        }

        public List<Curso> Cursos()
        {
            return _cursos;
        }
        public List<Bloco> Blocos()
        {
            return _blocos;
        }
        public List<Modulo> Modulos()
        {
            return _modulos;
        }
        public List<Turma> Turmas()
        {
            return _turmas;
        }
        public List<Aluno> Alunos()
        {
            return _alunos;
        }
        public List<Professor> Professores()
        {
            return _professores;
        }
    }
}