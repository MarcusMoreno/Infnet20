using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiceRecuperaDados
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRecuperaDados
    {
        //adicionar
        [OperationContract]
        void adicionaCurso(Curso curso);
        [OperationContract]
        void adicionaTurma(Turma turma);
        [OperationContract]
        void adicionaAluno(Aluno aluno);
        [OperationContract]
        void adicionaProfessor(Professor professor);

        //apagar
        [OperationContract]
        void apagarAlunos();
        [OperationContract]
        void apagarProfessores();
        [OperationContract]
        void apagarTurmas();
        [OperationContract]
        void apagarCursos();

        //recuperar
        [OperationContract]
        List<Aluno> RecuperaAlunos();
        [OperationContract]
        List<Professor> RecuperaProfessores();
        [OperationContract]
        List<Curso> RecuperaCursos();
        [OperationContract]
        List<Turma> RecuperaTurmas();
        [OperationContract]
        List<Modulo> RecuperaModulos();
        [OperationContract]
        List<Aluno> ListaDeAlunosDaTurma(Turma turma);
        [OperationContract]
        List<Aluno> ListaDeAlunosDaTurmaPorNome(String turma);

        [OperationContract]
        List<Turma> ListaDeTurmasDoCurso(Curso curso);

        [OperationContract]
        Turma turmaPorID(int id);
        [OperationContract]
        Turma turmaPorNome(string nome);
        [OperationContract]
        Aluno alunoPorId(int id);
        [OperationContract]
        Aluno alunoPorNome(string nome);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Turma
    {
        [DataMember]
        public Guid idTurma { get; set; }
        [DataMember]
        public string nomeTurma { get; set; }
        [DataMember]
        public int idModulo { get; set; }
        [DataMember]
        public int idProfessor { get; set; }
        [DataMember]
        public virtual Modulo modulo { get; set; }
        [DataMember]
        public virtual List<Aluno> alunos { get; set; }
        [DataMember]
        public virtual Professor professor { get; set; }
    }

    [DataContract]
    public class Curso
    {
        [DataMember]
        public Guid idCurso { get; set; }
        [DataMember]
        public string nomeCurso { get; set; }
        [DataMember]
        public virtual List<Turma> turmas { get; set; }
    }

    [DataContract]
    public class Professor
    {
        [DataMember]
        public Guid idProfessor { get; set; }
        [DataMember]
        public string nomeProfessor { get; set; }
        [DataMember]
        public char titulo { get; set; }
        [DataMember]
        public DateTime dataAdmissao { get; set; }
        [DataMember]
        public string email { get; set; }
    }

    [DataContract]
    public class Aluno
    {
        [DataMember]
        public Guid idAluno { get; set; }
        [DataMember]
        public string nomeAluno { get; set; }
        [DataMember]
        public string emailAluno { get; set; }
        [DataMember]
        public int idTurma { get; set; }
        [DataMember]
        public virtual Turma turma { get; set; }
    }

    [DataContract]
    public class Modulo
    {
        [DataMember]
        public Guid idModulo { get; set; }
        [DataMember]
        public string nomeModulo { get; set; }
        [DataMember]
        public List<Turma> turmas { get; set; }
        [DataMember]
        public virtual Bloco bloco { get; set; }
    }

    [DataContract]
    public class Bloco
    {
        [DataMember]
        public Guid idBloco { get; set; }
        [DataMember]
        public string nomeBloco { get; set; }
        [DataMember]
        public Curso curso { get; set; }
        [DataMember]
        public virtual List<Modulo> modulos { get; set; }
    }
}
