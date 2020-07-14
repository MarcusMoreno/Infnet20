using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaAppService _service;

        public TurmaController(ITurmaAppService turmaApp)
        {
            _service = turmaApp;
        }

        // GET: turma
        public ActionResult Index() => View(_service.GetAll().Select(TurmaMapper.BuildViewModelFrom));

        // GET: turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var TurmaViewModel = TurmaMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (TurmaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(TurmaViewModel);
        }

        // GET: turma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,Tipocurso")] TurmaViewModel TurmaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(TurmaViewModel);
            }

            var turma = TurmaMapper.ExtractFromViewModel(TurmaViewModel);
            _service.Add(turma);

            return RedirectToAction(nameof(Index));

        }

        // GET: turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var TurmaViewModel = TurmaMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (TurmaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(TurmaViewModel);
        }

        // POST: turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,Tipocurso")] TurmaViewModel TurmaViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(TurmaViewModel);
            }

            var turma = TurmaMapper.ExtractFromViewModel(TurmaViewModel);
            _service.Update(turma);

            return RedirectToAction(nameof(Details), new { id = turma.Id });
        }

        // GET: turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var TurmaViewModel = TurmaMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (TurmaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(TurmaViewModel);
        }

        // POST: turma/Delete/5
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