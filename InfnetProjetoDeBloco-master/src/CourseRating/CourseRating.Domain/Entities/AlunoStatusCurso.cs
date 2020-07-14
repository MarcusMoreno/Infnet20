namespace CourseRating.Domain.Entities
{
    public class AlunoStatusCurso
    {
        public int Id { get; set; }

        public Aluno Aluno { get; set; }

        public Curso Curso { get; set; }

        public StatusAlunoCurso Status { get; set; }
    }

    public enum StatusAlunoCurso
    {
        Cursando,
        Aprovado,
        Reprovado,
        Trancado
    }
}
