using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBase.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        
        [Display(Name = "Título")]
        public string Titulo { get; set; }
      
        [Display(Name = "Título Original")]
        public string TituloOriginal { get; set; }

        [Display(Name = "Genero")]
        public Genero Genero { get; set; }

        [Display(Name = "Atores")]
        public List<Ator> Atores { get; set; }

    }
}