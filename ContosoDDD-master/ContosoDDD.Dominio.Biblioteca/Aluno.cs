using System;
using System.Collections.Generic;

namespace ContosoDDD.Dominio.Biblioteca
{
    public class Aluno: Entidade.Aluno
    {
        ICollection<Emprestimo> Emprestimos { get; set; }
    }
}
