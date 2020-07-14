using CourseRating.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class CursoViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public IEnumerable<Bloco> Blocos { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}