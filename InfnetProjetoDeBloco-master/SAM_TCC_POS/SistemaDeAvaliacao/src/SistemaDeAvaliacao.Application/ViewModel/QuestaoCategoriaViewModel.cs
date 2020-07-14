using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class QuestaoCategoriaViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public ICollection<Questao> Questoes { get; set; }
    }
}
