using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Models
{
    public class PerfilViewModel
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public bool Status { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ReferenceId { get; set; }
    }
}