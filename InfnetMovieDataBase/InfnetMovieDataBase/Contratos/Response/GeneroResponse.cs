using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Response
{
    [DataContract]
    public class GeneroResponse
    {
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }

        [DataMember(Name = "filmes")]
        public List<FilmeResponse> Filmes { get; set; }
    }
}
