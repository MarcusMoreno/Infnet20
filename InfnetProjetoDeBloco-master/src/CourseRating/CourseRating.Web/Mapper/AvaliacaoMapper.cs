using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;

namespace CourseRating.Web.Mapper
{
    public class AvaliacaoMapper
    {
        public static Avaliacao ExtractFromViewModel(AvaliacaoViewModel viewModel)
        {
            var avaliacao = new Avaliacao
            {
                //TODO alterar
            };
            return avaliacao;
        }

        public static AvaliacaoViewModel BuildViewModelFrom(Avaliacao avaliacao)
        {
            var viewModel = new AvaliacaoViewModel
            {
                //TODO alterar
            };

            return viewModel;
        }
    }
}