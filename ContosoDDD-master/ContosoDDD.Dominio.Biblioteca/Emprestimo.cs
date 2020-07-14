using System;

namespace ContosoDDD.Dominio.Biblioteca
{
    internal class Emprestimo : BaseEntidade
    {
        public int AlunoId { get; set; }
        public int PublicacaoId { get; set; }

        public DateTime DataInicio { get; set; }

        public Aluno Aluno { get; set; }
        public Publicacao Publicacao { get; set; }

        public bool EmprestimoVencido()
        {
            return (DateTime.Now - DataInicio).Days > 30;
        }
    }
}