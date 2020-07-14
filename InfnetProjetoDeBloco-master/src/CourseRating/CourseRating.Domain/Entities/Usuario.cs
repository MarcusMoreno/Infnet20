namespace CourseRating.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public TipoAcessoUsuario TipoAcessoUsuario { get; set; }
    }

    public enum TipoAcessoUsuario
    {
        Administrador,
        Respondente
    }
}
