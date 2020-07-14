using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Web.Models;

namespace AvaliacaoInfnet.Web.Mapper
{
    public class AvaliacaoMapper
    {
        public static Avaliacao ExtractFromViewModel(AvaliacaoViewModel viewModel)
        {
            var avaliacao = new Avaliacao
            {
                //Perfil = viewModel.Perfil,
                Descricao = viewModel.Descricao,
                Status = viewModel.Status,
                //  Perguntas = viewModel.Perguntas,
            };
            return avaliacao;
        }

        public static AvaliacaoViewModel BuildViewModelFrom(Avaliacao avaliacao)
        {
            var viewModel = new AvaliacaoViewModel
            {
                //Perfil = avaliacao.Perfil,
                Descricao = avaliacao.Descricao,
                Status = avaliacao.Status,
                //Perguntas = avaliacao.Perguntas,
                Titulo = avaliacao.Titulo,
            };

            return viewModel;
        }
    }
}