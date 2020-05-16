using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMovieDataBase.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository)
        {
            this.pessoaRepository = pessoaRepository;
        }
        

        // GET: Pessoa
        public ActionResult Index()
        {            
            var pessoas = pessoaRepository.ListarPessoas();

            return View(pessoas);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            var pessoa = pessoaRepository.DetalharPessoa(id);

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
        public ActionResult Create([Bind] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoaRepository.CriarPessoa(pessoa);
                    return RedirectToAction("Index");
                }
                return View(pessoa);
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = pessoaRepository.DetalharPessoa(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.AtualizarPessoa(new Pessoa
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    DataNascimento = pessoa.DataNascimento
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
            var pessoa = pessoaRepository.DetalharPessoa(id);

            if (pessoa == null)
            {
                return StatusCode(404);
            }

            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pessoa pessoa)
        {
            pessoaRepository.ExcluirPessoa(pessoa.Id);
            return RedirectToAction("Index");
        }
    }
}