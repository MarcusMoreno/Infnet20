using System;

namespace CourseRating.Domain.Entities
{
    public class Avaliacao
    {
        public string Id { get; set; }

        public string Codigo { get; set; }

        public Questionario Questionario { get; set; }

        public string ObjetivoAvaliacao { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public Aluno Respondete { get; set; }

        public Professor Professor { get; set; }

        public Curso Curso { get; set; }

        public Turma Turma { get; set; }

        public bool Concluida { get; set; }
    }
}
