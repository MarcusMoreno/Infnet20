using AvaliacaoInfnet.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Models
{
    public class PerguntaViewModel
    {      
        [Required]
        public string Descricao { get; set; }

        [Required]
        public bool Status { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int ReferenceId { get; set; }

        //Tipo resposta
        [Required]
        public Dictionary<TipoResposta, bool> TipoRespostas { get; set; }
                
        public List<string> SelectedTipoResposta { get; set; }

    }
}