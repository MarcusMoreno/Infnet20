using CourseRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class TurmaViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime PeriodoMinistradoInicio { get; set; }
        [Required]
        public DateTime PeriodoMinistradoFim { get; set; }
        [Required]
        public Modulo Modulo { get; set; }
        [Required]
        public IEnumerable<Aluno> Alunos { get; set; }
        [Required]
        public Professor Professor { get; set; }

    }

}