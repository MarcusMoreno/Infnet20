using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public class Questionario
    {
        public int Id { get; set; }

        public string Detalhe { get; set; }

        public IEnumerable<ModuloQuestionario> Questionarios { get; set; }
    }
}
