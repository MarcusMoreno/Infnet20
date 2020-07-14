using CourseRating.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CourseRating.Web.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public TipoAcessoUsuario TipoUsuario { get; set; }
    }
}