using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoAppService _service;

        public AlunoController(IAlunoAppService alunoApp)
        {
            _service = alunoApp;
        }

        // GET: Aluno
        public ActionResult Index() => View(_service.GetAll().Select(AlunoMapper.BuildViewModelFrom));

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var alunoViewModel = AlunoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (alunoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(alunoViewModel);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,TipoAluno")] AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(alunoViewModel);
            }

            var Aluno = AlunoMapper.ExtractFromViewModel(alunoViewModel);
            _service.Add(Aluno);

            return RedirectToAction(nameof(Index));

        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var alunoViewModel = AlunoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (alunoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(alunoViewModel);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,TipoAluno")] AlunoViewModel alunoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(alunoViewModel);
            }

            var Aluno = AlunoMapper.ExtractFromViewModel(alunoViewModel);
            _service.Update(Aluno);

            return RedirectToAction(nameof(Details), new { id = Aluno.Id });
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var alunoViewModel = AlunoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (alunoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(alunoViewModel);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _service.Remove(_service.GetById(id));

            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}