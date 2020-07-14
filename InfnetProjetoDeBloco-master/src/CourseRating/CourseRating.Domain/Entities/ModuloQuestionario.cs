using System.Collections.Generic;

namespace CourseRating.Domain.Entities
{
    public class ModuloQuestionario
    {
        public int Id { get; set; }

        public string Detalhe { get; set; }

        public IEnumerable<string> Respostas { get; set; }

        public IEnumerable<string> Perguntas { get; set; }

        public CategoriaQuestionario Categoria { get; set; }
    }

    public enum CategoriaQuestionario
    {
        DuracaoAulas,
        TempoCurso,
        Professores,
        MaterialEnsino,
        Instalações
    }
}
