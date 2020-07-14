using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public  class Bloco
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public IEnumerable<Modulo> Modulos { get; set; }
    }
}
