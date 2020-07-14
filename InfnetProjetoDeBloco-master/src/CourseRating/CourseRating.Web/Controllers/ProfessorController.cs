using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorAppService _service;

        public ProfessorController(IProfessorAppService professorApp)
        {
            _service = professorApp;
        }

        // GET: Professor
        public ActionResult Index() => View(_service.GetAll().Select(ProfessorMapper.BuildViewModelFrom));

        // GET: Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var professorViewModel = ProfessorMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (professorViewModel == null)
            {
                return HttpNotFound();
            }
            return View(professorViewModel);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Usuario,Coodernador")] ProfessorViewModel professorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(professorViewModel);
            }

            var professor = ProfessorMapper.ExtractFromViewModel(professorViewModel);
            _service.Add(professor);

            return RedirectToAction(nameof(Index));

        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var professorViewModel = ProfessorMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (professorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(professorViewModel);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Usuario,Coodernador")] ProfessorViewModel professorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(professorViewModel);
            }

            var professor = ProfessorMapper.ExtractFromViewModel(professorViewModel);
            _service.Update(professor);

            return RedirectToAction(nameof(Details), new { id = professor.Id });
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var professorViewModel = ProfessorMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (professorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(professorViewModel);
        }

        // POST: Professor/Delete/5
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