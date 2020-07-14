using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoInfnet.Web.Mapper
{
    public class EntrevistadoMapper
    {
        public static Entrevistado ExtractFromViewModel(EntrevistadoViewModel viewModel, List<Perfil> perfis)
        {
            var entrevistado = new Entrevistado
            {
                Id = viewModel.Id,
                Email = viewModel.Email,
                Nome = viewModel.Nome,
                Status = viewModel.Status,
                Telefone = viewModel.Telefone,
                Senha = viewModel.Senha,
                Perfil = new List<Perfil>(),
            };

            if (viewModel.SelectedPerfil != null)
            {
                entrevistado.Perfil = perfis.Where(x => viewModel.SelectedPerfil.Contains(x.Id.ToString())).ToList();
            }

            return entrevistado;
        }

        public static EntrevistadoViewModel BuildViewModelFrom(Entrevistado entrevistado, List<Perfil> allPerfil)
        {
            var perfilEntrevistadoViewModel = new Dictionary<Perfil, bool>();

            var viewModel = new EntrevistadoViewModel
            {
                Email = entrevistado.Email,
                Nome = entrevistado.Nome,
                Status = entrevistado.Status,
                Id = entrevistado.Id,
                Senha = entrevistado.Senha,
                Telefone = entrevistado.Telefone,
            };

            if (allPerfil != null)
            {
                foreach (var perfil in allPerfil)
                {
                    if (entrevistado.Perfil.Any(x => x.Id == perfil.Id))
                    {
                        perfilEntrevistadoViewModel.Add(perfil, true);
                    }
                    else
                    {
                        perfilEntrevistadoViewModel.Add(perfil, false);
                    }
                }
            }

            viewModel.Perfis = perfilEntrevistadoViewModel;

            return viewModel;
        }
    }
}