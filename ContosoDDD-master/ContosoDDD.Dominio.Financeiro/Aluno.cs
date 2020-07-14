using System;

namespace ContosoDDD.Dominio.Financeiro
{
    public class Aluno : Entidade.Aluno
    {
        public bool PagamentoUnico { get; set; }
        public MeioPagamento MeioPagamento { get; set; }
        public DateTime UltimoPagamento { get; set; }

        public bool Adimplente()
        {
            return PagamentoUnico || 
                    AlunoAtivo() && (DateTime.Now - UltimoPagamento).Days <= 45;
        }
    }
}
