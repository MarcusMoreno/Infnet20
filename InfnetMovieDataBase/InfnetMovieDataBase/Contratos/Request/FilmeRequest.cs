using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Request
{
    [DataContract]
    public class FilmeRequest
    {
        [DataMember(Name = "titulo")]
        public string Titulo { get; set; }

        [DataMember(Name = "tituloOriginal")]
        public string TituloOriginal { get; set; }

        [DataMember(Name = "generoId")]
        public string Genero { get; set; }

        [DataMember(Name = "atores")]
        public List<string> Atores { get; set; }
    }
}
