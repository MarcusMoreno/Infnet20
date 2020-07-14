using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoDDD.Dominio.Entidade
{
    public class Aluno : BaseEntidade
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataMatricula { get; set; }
        public DateTime UltimoAcesso { get; set; }
      
        public ICollection<Matricula> Matriculas { get; set; }

        public bool AlunoAtivo()
        {
            TimeSpan intervalo = UltimoAcesso - DataMatricula;
            return intervalo.Days <= 180;
        }

        public bool RegimeEspecial()
        {
            return DataMatricula.Year <= 2014;
        }
    }
}
