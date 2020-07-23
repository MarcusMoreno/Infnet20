using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class GeneroController : Controller
    {
        private readonly IGeneroRepository generoRepository;
        private readonly IFilmeRepository filmeRepository;
        private readonly IFilmeGeneroRepository filmeGeneroRepository;

        public GeneroController(IGeneroRepository repository, IFilmeRepository filmeRepository, IFilmeGeneroRepository filmeGeneroRepository)
        {
            this.generoRepository = repository;
            this.filmeRepository = filmeRepository;
            this.filmeGeneroRepository = filmeGeneroRepository;
        }

        public ActionResult Index()
        {
            var generos = generoRepository.ListarGenero();

            return View(generos);
        }
      
        public ActionResult Details(int id)
        {
            var genero = generoRepository.DetalharGenero(id);

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
                    var generoId = generoRepository.CriarGenero(genero);
                    if (genero.Filmes != null)
                    {
                        for (int i = 0; i < genero.Filmes.Count; i++)
                        {
                           //TODO validar se filmeId existe
                            filmeGeneroRepository.CreateOrUpdateFilmeGenero(genero.Filmes[i].Id.ToString(), generoId);
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    
        public ActionResult Edit(int id)
        {
            var genero = generoRepository.DetalharGenero(id);
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
                    generoRepository.AtualizarGenero(genero);

                    for (int i = 0; i < genero.Filmes.Count; i++)
                    {
                        //TODO validar se filmeId existe
                        filmeGeneroRepository.CreateOrUpdateFilmeGenero(genero.Filmes[i].Id.ToString(), genero.Id.ToString());
                    }

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
