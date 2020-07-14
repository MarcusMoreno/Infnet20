using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class AlunoViewModel
    {
        [Required]
        public int Matricula { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Status { get; set; }
    }
}