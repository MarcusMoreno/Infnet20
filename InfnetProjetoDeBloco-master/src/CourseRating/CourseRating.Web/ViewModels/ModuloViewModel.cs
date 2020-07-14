using System;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class ModuloViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
    }
}