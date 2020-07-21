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
        

        // GET: Pessoa
        public ActionResult Index()
        {            
            var pessoas = atorRepository.ListarAtores();

            return View(pessoas);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
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
                            var filmeId = filmeRepository.CriarFilme(ator.Filmes[i]);
                            filmeAtorRepository.CriarFilmeAtor(filmeId, atorId);
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

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ator pessoa)
        {
            if (ModelState.IsValid)
            {
                atorRepository.AtualizarAtor(new Ator
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome
                });
                return RedirectToAction("Index");
            }
            else
            {
                return View(pessoa);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            var pessoa = atorRepository.DetalharAtor(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ator pessoa)
        {
            atorRepository.ExcluirAtor(pessoa.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Filme(int id)
        {
            var elenco = atorRepository.ListarFilme(id);
            return View(elenco);
        }
    }
}