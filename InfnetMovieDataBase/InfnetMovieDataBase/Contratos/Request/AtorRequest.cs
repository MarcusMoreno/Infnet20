using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Request
{
    [DataContract]
    public class AtorRequest
    {


        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "sobrenome")]
        public string Sobrenome { get; set; }

        [DataMember(Name = "filmes")]
        public List<string> Filmes { get; set; }
    }
}
