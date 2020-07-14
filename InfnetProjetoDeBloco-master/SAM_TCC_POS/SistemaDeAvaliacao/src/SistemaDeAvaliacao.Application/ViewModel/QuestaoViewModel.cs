using SistemaDeAvaliacao.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class QuestaoViewModel
    {
        [Key]
        [DisplayName("Id")]
        public int QuestaoId { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        //Popular dropdownlist
        public IEnumerable<QuestaoCategoriaViewModel> ListaDeCategorias { get; set; }

        public QuestaoCategoria Categoria { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }
        public ICollection<AvaliacaoResposta> Respostas { get; set; }
    }
}
