using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBase.Domain
{
    public class Genero
    {
        public int Id { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
      
        [Display(Name = "Filmes")]
        public List<Filme> Filmes { get; set; }

    }
}
