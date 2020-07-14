using CourseRating.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class QuestionarioViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Detalhe { get; set; }
        [Required]
        public IEnumerable<ModuloQuestionario> Questionarios { get; set; }
    }
}