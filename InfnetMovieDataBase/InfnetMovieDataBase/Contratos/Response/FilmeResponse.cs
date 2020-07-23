using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetMovieDataBase.Contratos.Response
{
    [DataContract]
    public class FilmeResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "titulo")]       
        public string Titulo { get; set; }

        [DataMember(Name = "tituloOriginal")]
        public string TituloOriginal { get; set; }

        [DataMember(Name = "genero", EmitDefaultValue =false)]
        public GeneroResponse Genero { get; set; }

        [DataMember(Name = "atores", EmitDefaultValue = false)]
        public List<AtorResponse> Atores { get; set; }
    }
}
