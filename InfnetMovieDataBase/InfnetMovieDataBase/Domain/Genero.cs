using System.ComponentModel.DataAnnotations;

namespace InfnetMovieDataBase.Domain
{
    public class Genero
    {
        public int Id { get; set; }

        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
