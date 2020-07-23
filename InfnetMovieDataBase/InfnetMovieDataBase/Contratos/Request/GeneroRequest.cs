using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Request
{
    [DataContract]
    public class GeneroRequest
    {
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        [DataMember(Name = "filmes")]
        public List<string> Filmes { get; set; }
    }
}
