using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroRepository repository;

        public GeneroController(IGeneroRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var generos = repository.ListarGenero();

            return View(generos);
        }
        public ActionResult Filme(int id)
        {
            var filme = repository.ListarFilme(id);
            return View(filme);
        }

        public ActionResult Details(int id)
        {
            var genero = repository.DetalharGenero(id);

            return View(genero);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.CriarGenero(genero);
                    return RedirectToAction(nameof(Index));
                }
                return View(genero);

            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var genero = repository.DetalharGenero(id);
            return View(genero);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genero genero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repository.AtualizarGenero(genero);
                    return RedirectToAction(nameof(Index));
                }
                return View(genero);
            }
            catch
            {
                return View();
            }
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Filme/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
