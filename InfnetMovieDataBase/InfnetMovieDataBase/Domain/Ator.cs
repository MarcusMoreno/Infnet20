using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Domain
{
    [DataContract]
    public class Ator
    {
        [DataMember(Name = "atorId")]
        public int Id { get; set; }

        [DataMember(Name = "nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [DataMember(Name = "sobrenome")]
        [Display(Name = "Sobrenome")]
        public string Sobrenome { get; set; }

        [DataMember(Name = "filmes")]
        [Display(Name = "Filmes")]
        public List<Filme> Filmes { get; set; }
    }
}
