using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;

namespace CourseRating.Web.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario ExtractFromViewModel(UsuarioViewModel viewModel)
        {
            var usuario = new Usuario
            {
                Id = viewModel.Id,
                Login = viewModel.Login,
                Senha = viewModel.Senha,
                TipoAcessoUsuario = viewModel.TipoUsuario
            };

            return usuario;
        }

        public static UsuarioViewModel BuildViewModelFrom(Usuario usuario)
        {
            var viewModel = new UsuarioViewModel
            {
                Senha = usuario.Senha,
                Login = usuario.Login,
                Id = usuario.Id,
                TipoUsuario = usuario.TipoAcessoUsuario
            };

            return viewModel;
        }
    }
}