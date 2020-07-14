using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;

namespace CourseRating.Web.Mapper
{
    public class ProfessorMapper
    {
        public static Professor ExtractFromViewModel(ProfessorViewModel viewModel)
        {
            var Professor = new Professor
            {
                Id = viewModel.Id,
                Email = viewModel.Email,
                Usuario = viewModel.Usuario,
                Coordernador = viewModel.Coordernador
            };

            return Professor;
        }

        public static ProfessorViewModel BuildViewModelFrom(Professor Professor)
        {
            var viewModel = new ProfessorViewModel
            {
                Id = Professor.Id,
                Email = Professor.Email,
                Usuario = Professor.Usuario,
                Coordernador = Professor.Coordernador
            };

            return viewModel;
        }
    }
}