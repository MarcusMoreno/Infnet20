using ContosoDDD.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContosoDDD.MVC.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoServicoAplicacao _alunoServicoAplicacao;

        public AlunoController(IAlunoServicoAplicacao alunoServicoAplicacao)
        {
            _alunoServicoAplicacao = alunoServicoAplicacao;
        }

        // GET: Aluno
        public ActionResult Index()
        {
            return View(_alunoServicoAplicacao.Listar());
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aluno/Delete/5
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