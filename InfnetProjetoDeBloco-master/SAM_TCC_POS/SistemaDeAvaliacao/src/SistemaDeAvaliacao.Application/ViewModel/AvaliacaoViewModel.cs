using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class AvaliacaoViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int AvaliacaoId { get; set; }

        [DisplayName("Código de Acesso")]
        public Guid CodigoAcesso { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(300, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Data de Término")]
        public DateTime DataTermino { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Turma")]
        public int TurmaId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Professor { get; set; }

        [Required(ErrorMessage = "É obrigatória a seleção de pelo menos uma pergunta")]
        public IList<int> IdQuestoesSelecionadas { get; set; }

        public IList<QuestaoViewModel> ListaQuestoes { get; set; }
        public IList<QuestaoCategoriaViewModel> ListaCategorias { get; set; }

        public ICollection<Questao> Questoes { get; set; }
        public ICollection<AvaliacaoResposta> Respostas { get; set; }
    }
}
