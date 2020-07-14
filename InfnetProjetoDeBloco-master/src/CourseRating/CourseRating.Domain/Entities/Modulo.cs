using System;

namespace CourseRating.Domain.Entities
{
    public class Modulo
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }
    }
}