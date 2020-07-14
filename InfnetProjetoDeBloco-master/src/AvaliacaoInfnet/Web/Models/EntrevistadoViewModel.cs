using AvaliacaoInfnet.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Models
{
    public class EntrevistadoViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool Status { get; set; }

        public string Telefone { get; set; }

        public string Senha { get; set; }

        public Dictionary<Perfil, bool> Perfis { get; set; }

        public List<string> SelectedPerfil { get; set; }
    }
}