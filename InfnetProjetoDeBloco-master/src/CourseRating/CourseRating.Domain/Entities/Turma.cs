using System;
using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public class Turma
    {
        public string Id { get; set; }

        public DateTime PeriodoMinistradoInicio { get; set; }

        public DateTime PeriodoMinistradoFim { get; set; }

        public Modulo Modulo { get; set; }

        public IEnumerable<Aluno> Alunos { get; set; }

        public Professor Professor { get; set; }
    }
}
