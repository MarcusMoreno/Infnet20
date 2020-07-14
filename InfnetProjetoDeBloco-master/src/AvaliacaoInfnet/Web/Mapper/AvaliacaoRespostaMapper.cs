using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoInfnet.Web.Mapper
{
    public class AvaliacaoRespostaMapper
    {
        public static AvaliacaoResposta ExtractFromViewModel(AvaliacaoRespostaViewModel viewModel)
        {
            var avaliacaoResposta = new AvaliacaoResposta
            {
                Id = viewModel.Id,
                perfil = viewModel.Perfil,
            };

            return avaliacaoResposta;
        }

        public static AvaliacaoRespostaViewModel BuildViewModelFrom(AvaliacaoResposta avaliacaoResposta, ICollection<Pergunta> perguntas = null)
        {
            var viewModel = new AvaliacaoRespostaViewModel()
            {
                Titulo = avaliacaoResposta.Titulo,
                Status = avaliacaoResposta.Status,
            };

            if(perguntas != null)
            {
                //Adiciona os tiposRespostas
                foreach (var pergunta in perguntas)
                {
                    if (avaliacaoResposta.Perguntas.Contains(pergunta))//Caso esteja selecionado
                    {
                        viewModel.Perguntas.Add(pergunta, true);
                    }
                    else
                    {
                        viewModel.Perguntas.Add(pergunta, false);
                    }
                }
            }

            var viewModel = new EntrevistadoViewModel
            {
                Email = entrevistado.Email,
                Nome = entrevistado.Nome,
                Status = entrevistado.Status,
                Id = entrevistado.Id,
                Senha = entrevistado.Senha,
                Telefone = entrevistado.Telefone,
            };

            foreach (var perfil in allPerfil)
            {
                if (entrevistado.Perfil.Contains(perfil))
                {
                    perfilEntrevistadoViewModel.Add(perfil, true);
                }
                else
                {
                    perfilEntrevistadoViewModel.Add(perfil, false);
                }
            }

            viewModel.Perfis = perfilEntrevistadoViewModel;

            return viewModel;
        }
    }
}