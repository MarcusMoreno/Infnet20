using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;

namespace CourseRating.Web.Mapper
{
    public class TurmaMapper
    {
        public static Turma ExtractFromViewModel(TurmaViewModel viewModel)
        {
            var turma = new Turma
            {
                Id = viewModel.Id,
                Modulo = viewModel.Modulo
                //TODO Adicionar todos os atributos
            };
            return turma;
        }


        public static TurmaViewModel BuildViewModelFrom(Turma turma)
        {
            var viewModel = new TurmaViewModel
            {
                Id = turma.Id,
                Modulo = turma.Modulo,
                //TODO Adicionar todos os atributos
            };

            return viewModel;
        }
    }
}