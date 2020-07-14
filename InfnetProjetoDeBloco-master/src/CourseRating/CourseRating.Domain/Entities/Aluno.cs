namespace CourseRating.Domain.Entities
{
    public class Aluno : Pessoa
    {
        public int Matricula { get; set; }

        public string Email { get; set; }

        public Usuario Usuario { get; set; }
    }
}
