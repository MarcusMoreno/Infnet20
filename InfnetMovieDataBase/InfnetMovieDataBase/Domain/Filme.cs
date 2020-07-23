using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Domain
{
    [DataContract]
    public class Filme
    {
        public int Id { get; set; }
        
        [DataMember(Name ="titulo")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
     
        [DataMember(Name = "tituloOriginal")]
        [Display(Name = "Título Original")]
        public string TituloOriginal { get; set; }

        [DataMember(Name = "genero")]
        [Display(Name = "Genero")]
        public Genero Genero { get; set; }

        [DataMember(Name = "atores")]
        [Display(Name = "Atores")]
        public List<Ator> Atores { get; set; }

    }
}