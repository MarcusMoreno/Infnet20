using System.Collections.Generic;

namespace ContosoDDD.Dominio.Biblioteca
{
    public class Publicacao : BaseEntidade
    {
        public string Titulo { get; set; }
        public int Quantidade { get; set; }

        ICollection<Emprestimo> Emprestimos { get; set; }
    }
}