using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository filmeRepository;
        private readonly IAtorRepository atorRepository;
        private readonly IFilmeAtorRepository filmeAtorRepository;

        public FilmeController(IFilmeRepository filmeRepository, IAtorRepository atorRepository, IFilmeAtorRepository filmeAtorRepository)
        {
            this.filmeRepository = filmeRepository;
            this.atorRepository = atorRepository;
            this.filmeAtorRepository = filmeAtorRepository;
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

            //filme.Atores = new System.Collections.Generic.List<Ator>();
            //filme.Atores.Add(new Ator() { Nome = "Fernanda", Sobrenome = "Montengro" });

            try
            {              
                if (ModelState.IsValid)
                {
                    var filmeId = filmeRepository.CriarFilme(filme);
                    if (filme.Atores != null)
                    {
                        for (int i = 0; i < filme.Atores.Count; i++)
                        {
                            var atorId = atorRepository.CriarAtor(filme.Atores[i]);
                            filmeAtorRepository.CriarFilmeAtor(filmeId, atorId);
                        }
                    }
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