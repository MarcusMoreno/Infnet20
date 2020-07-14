using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliacaoInfnet.Web.Models
{
    public class AvaliacaoRespostaViewModel
    {
        //Avaliacao
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}