using SistemaDeAvaliacao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeAvaliacao.Application.ViewModel
{
    public class AvaliacaoRespostaViewModel
    {
        public int AvaliacaoRespostaId { get; set; }
        public int AvaliacaoId { get; set; }
        public int MatriculaAluno { get; set; }
        public string NomeAluno { get; set; }
        public int QuestaoId { get; set; }
        public int Resposta { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
