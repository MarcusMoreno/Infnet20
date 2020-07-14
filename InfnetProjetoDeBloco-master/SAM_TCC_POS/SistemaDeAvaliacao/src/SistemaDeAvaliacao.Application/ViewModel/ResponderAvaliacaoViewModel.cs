using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class ResponderAvaliacaoViewModel
    {
        //public int AvaliacaoRespostaId { get; set; }
        public int AvaliacaoId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Matrícula")]
        public int MatriculaAluno { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Aluno")]
        public string NomeAluno { get; set; }

        public int QuestaoId { get; set; }
        public int Resposta { get; set; }
        public DateTime DataCadastro { get; set; }

        //Avaliacao
        public Guid CodigoAcesso { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(300, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Objetivo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Término")]
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

        //public AvaliacaoViewModel Avaliacao { get; set; }
        public IList<QuestaoViewModel> Questoes { get; set; }
        public IList<OpcaoRespostaViewModel> OpcoesResposta { get; set; }
        public IList<AvaliacaoRespostaViewModel> AvaliacaoRespostas { get; set; }
        //public OpcaoResposta OpcaoResposta { get; set; }
    }
}
