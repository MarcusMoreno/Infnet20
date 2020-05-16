using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository filmeRepository;
   
        public FilmeController(IFilmeRepository filmeRepository)
        {
            this.filmeRepository = filmeRepository;
        }
        

        public ActionResult Index()
        {
            var filmes = filmeRepository.ListarFilmes();

            return View(filmes);
        }

        public ActionResult Elenco(int id)
        {
            var elenco = filmeRepository.ListarElenco(id);
            return View(elenco);
        }

        // GET: Filme/Details/5
        public ActionResult Details(int id)
        {
            var filme = filmeRepository.DetalharFilme(id);

            return View(filme);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    filmeRepository.CriarFilme(filme);
                    return RedirectToAction(nameof(Index));
                }
                return View(filme);

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var filme = filmeRepository.DetalharFilme(id);
            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Filme filme)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    filmeRepository.AtualizarFilme(filme);
                    return RedirectToAction(nameof(Index));
                }
                return View(filme);

            }
            catch
            {
                return View();
            }
        }

   
        public ActionResult Delete(int id)
        {
            var filme = filmeRepository.DetalharFilme(id);

            if (filme == null)
            {
                return StatusCode(404);
            }

            return View(filme);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Filme filme)
        {
            filmeRepository.ExcluirFilme(filme.Id);
            return RedirectToAction("Index");
        }
    }
}