using CourseRating.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class ProfessorViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Usuario Usuario { get; set; }

        [Required]
        public bool Coordernador { get; set; }
    }
}