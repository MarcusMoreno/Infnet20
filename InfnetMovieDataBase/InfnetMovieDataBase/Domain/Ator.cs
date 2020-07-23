using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBase.Domain
{
    public class Ator
    {
            public int Id { get; set; }
       
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [Display(Name = "Filmes")]
        public List<Filme> Filmes { get; set; }
    }
}
