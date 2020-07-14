using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public class Curso
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Bloco> Blocos { get; set; }
    }
}