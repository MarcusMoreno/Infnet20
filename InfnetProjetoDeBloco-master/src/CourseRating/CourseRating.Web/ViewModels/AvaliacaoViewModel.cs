using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class AvaliacaoViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Status { get; set; }
    }
}