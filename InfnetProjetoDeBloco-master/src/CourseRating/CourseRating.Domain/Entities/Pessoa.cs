using System;

namespace CourseRating.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Sexo { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
