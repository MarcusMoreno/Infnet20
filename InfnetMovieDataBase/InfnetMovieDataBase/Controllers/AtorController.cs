using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class AtorController : Controller
    {
        private readonly IAtorRepository atorRepository;
        private readonly IFilmeRepository filmeRepository;
        private readonly IFilmeAtorRepository filmeAtorRepository;

        public AtorController(IAtorRepository pessoaRepository, IFilmeRepository filmeRepository, IFilmeAtorRepository filmeAtorRepository)
        {
            this.atorRepository = pessoaRepository;
            this.filmeRepository = filmeRepository;
            this.filmeAtorRepository = filmeAtorRepository;
        }


    
        public ActionResult Index()
        {
            var pessoas = atorRepository.ListarAtores();

            return View(pessoas);
        }

        public ActionResult Details(int id)
        {
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ator ator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var atorId = atorRepository.CriarAtor(ator);
                    if (ator.Filmes != null)
                    {                     
                        for (int i = 0; i < ator.Filmes.Count; i++)
                        {
                            //TODO valida ser filme existe
                            filmeAtorRepository.CreateOrUpdateFilmeAtor(ator.Filmes[i].Id.ToString(), atorId);
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
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ator ator)
        {
            if (ModelState.IsValid)
            {
                atorRepository.AtualizarAtor(ator);

                if (ator.Filmes != null)
                {
                    for (int i = 0; i < ator.Filmes.Count; i++)
                    { 
                        //TODO valida ser filme existe
                        filmeAtorRepository.CreateOrUpdateFilmeAtor(ator.Filmes[i].Id.ToString(), ator.Id.ToString());
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(ator);
            }
        }

       
        public ActionResult Delete(int id)
        {
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ator pessoa)
        {
            atorRepository.ExcluirAtor(pessoa.Id);
            return RedirectToAction("Index");
        }

    }
}