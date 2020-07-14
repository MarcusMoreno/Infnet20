namespace ContosoDDD.Dominio.Entidade
{
    public enum Conceito
    {
        ND, D, DL, DML
    }

    public class Matricula : BaseEntidade
    {
        public int CursoId { get; set; }
        public int AlunoId { get; set; }
        public Conceito? Conceito { get; set; }

        public Curso Curso { get; set; }
        public Aluno Aluno { get; set; }
    }
}