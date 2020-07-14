using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public class Professor : Pessoa
    {
        public string Email { get; set; }

        public IEnumerable<Turma> Turmas { get; set; }

        public Usuario Usuario { get; set; }

        public bool Coordernador { get; set; }
    }
}
