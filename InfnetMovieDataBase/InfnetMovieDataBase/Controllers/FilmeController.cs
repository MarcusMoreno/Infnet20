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
        private readonly IGeneroRepository generoRepository;
        private readonly IFilmeGeneroRepository filmeGeneroRepository;

        public FilmeController(IFilmeRepository filmeRepository, IAtorRepository atorRepository, IFilmeAtorRepository filmeAtorRepository, IGeneroRepository generoRepository, IFilmeGeneroRepository filmeGeneroRepository)
        {
            this.filmeRepository = filmeRepository;
            this.atorRepository = atorRepository;
            this.filmeAtorRepository = filmeAtorRepository;
            this.generoRepository = generoRepository;
            this.filmeGeneroRepository = filmeGeneroRepository;
        }
        

        public ActionResult Index()
        {
            var filmes = filmeRepository.ListarFilmes();

            return View(filmes);
        }

        public ActionResult Details(int id)
        {
            var filme = filmeRepository.DetalharFilme(id);

            return View(filme);
        }

        public ActionResult Create()
        {
            var generoList = generoRepository.ListarGenero();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filme filme)
        {
            filme.Atores = new System.Collections.Generic.List<Ator>();
            filme.Atores.Add(new Ator() { Id = 3 });

            try
            {              
                if (ModelState.IsValid)
                {
                    var filmeId = filmeRepository.CriarFilme(filme);
                    if (filme.Atores != null)
                    {
                        for (int i = 0; i < filme.Atores.Count; i++)
                        {
                            //TODO validar se atorId existe
                            filmeAtorRepository.CreateOrUpdateFilmeAtor(filmeId, filme.Atores[i].Id.ToString());
                        }
                    }
                    if (filme.Genero != null)
                    {
                        //TODO validar se generoId existe
                        filmeGeneroRepository.CreateOrUpdateFilmeGenero(filmeId, filme.Id.ToString()); ;
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
                    for (int i = 0; i < filme.Atores.Count; i++)
                    {
                        //TODO validar se atorId existe
                        filmeAtorRepository.CreateOrUpdateFilmeAtor(filme.Id.ToString(), filme.Atores[i].Id.ToString());
                    }
                    if (filme.Genero != null)
                    {
                        //TODO validar se generoId existe
                        filmeGeneroRepository.CreateOrUpdateFilmeGenero(filme.Id.ToString(), filme.Id.ToString());
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