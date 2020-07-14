using System;
using System.Collections.Generic;
using System.Text;

namespace ContosoDDD.Dominio.Entidade
{
    public class Curso : BaseEntidade
    {
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }

        public bool EmAndamento()
        {
            return DateTime.Now >= DataInicio && DateTime.Now <= DataFim;
        }
    }
}
