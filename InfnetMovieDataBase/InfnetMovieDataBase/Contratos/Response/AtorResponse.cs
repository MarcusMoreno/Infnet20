using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Response
{
    [DataContract]
    public class AtorResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "nome")]
        public string Nome { get; set; }

        [DataMember(Name = "sobrenome")]
        public string Sobrenome { get; set; }

        [DataMember(Name = "filmes")]
        public List<FilmeResponse> Filmes { get; set; }
    }
}
