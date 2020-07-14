using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;

namespace CourseRating.Web.Mapper
{
    public class ModuloMapper
    {
        public static Modulo ExtractFromViewModel(ModuloViewModel viewModel)
        {
            var modulo = new Modulo
            {
                Id = viewModel.Id,
                Nome = viewModel.Name,
                DataInicio = viewModel.DataInicio,
                DataTermino = viewModel.DataTermino
                //TODO Adicionar todos os atributos
            };
            return modulo;
        }


        public static ModuloViewModel BuildViewModelFrom(Modulo modulo)
        {
            var viewModel = new ModuloViewModel
            {
                Id = modulo.Id,
                Name = modulo.Nome,
                DataInicio = modulo.DataInicio,
                DataTermino = modulo.DataTermino
                //TODO Adicionar todos os atributos
            };

            return viewModel;
        }
    }
}