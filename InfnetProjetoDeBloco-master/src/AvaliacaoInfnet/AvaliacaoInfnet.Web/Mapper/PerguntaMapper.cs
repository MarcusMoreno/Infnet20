using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Web.Models;
using System.Collections;
using System.Collections.Generic;

namespace AvaliacaoInfnet.Web.Mapper
{
    public class PerguntaMapper
    {
        public static Pergunta ExtractFromViewModel(PerguntaViewModel viewModel)
        {
            var pergunta = new Pergunta
            {
                Descricao = viewModel.Descricao,
                Status = viewModel.Status,
            };
            return pergunta;
        }

        public static PerguntaViewModel BuildViewModelFrom(Pergunta pergunta, ICollection<TipoResposta> tipoRespostas = null )
        {
            var viewModel = new PerguntaViewModel()
            {
                Descricao = pergunta.Descricao,
                Status = pergunta.Status,               
            };

            if (tipoRespostas != null)
            {
                //Adiciona os tiposRespostas
                foreach (var tipo in tipoRespostas)
                {
                    if (pergunta.TipoRespostas.Contains(tipo))//Caso esteja selecionado
                    {
                        viewModel.TipoRespostas.Add(tipo, true);
                    }
                    else
                    {
                        viewModel.TipoRespostas.Add(tipo, false);
                    }
                }
            }

            return viewModel;
        }
    }
}