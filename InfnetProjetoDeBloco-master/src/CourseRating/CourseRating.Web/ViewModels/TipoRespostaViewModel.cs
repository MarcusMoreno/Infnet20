using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class TipoRespostaViewModel
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}