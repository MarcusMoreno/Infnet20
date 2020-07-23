using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Domain
{
    [DataContract]
    public class Genero
    {
        [DataMember(Name = "generoId")]
        public int Id { get; set; }

        [DataMember(Name = "descricao")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        [DataMember(Name = "filmes")]
        [Display(Name = "Filmes")]
        public List<Filme> Filmes { get; set; }

    }
}
