using SistemaDeAvaliacao.Application.Interface;
using System.Web.Mvc;

namespace SistemaDeAvaliacao.MVC.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        //private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(_usuarioAppService.ObterTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(string id)
        {
            return View(_usuarioAppService.ObterPorId(id));
        }

        public ActionResult DesativarLock(string id)
        {
            _usuarioAppService.DesativarLock(id);
            return RedirectToAction("Index");
        }
    }
}
