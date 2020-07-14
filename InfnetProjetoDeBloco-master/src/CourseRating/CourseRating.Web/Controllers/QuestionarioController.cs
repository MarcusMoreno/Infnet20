using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class QuestionarioController : Controller
    {
        private readonly IQuestionarioAppService _service;

        public QuestionarioController(IQuestionarioAppService questionarioApp)
        {
            _service = questionarioApp;
        }

        // GET: Questionario
        public ActionResult Index() => View(_service.GetAll().Select(QuestionarioMapper.BuildViewModelFrom));

        // GET: Questionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var QuestionarioViewModel = QuestionarioMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (QuestionarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(QuestionarioViewModel);
        }

        // GET: Questionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,TipoQuestionario")] QuestionarioViewModel QuestionarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(QuestionarioViewModel);
            }

            var Questionario = QuestionarioMapper.ExtractFromViewModel(QuestionarioViewModel);
            _service.Add(Questionario);

            return RedirectToAction(nameof(Index));

        }

        // GET: Questionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var QuestionarioViewModel = QuestionarioMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (QuestionarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(QuestionarioViewModel);
        }

        // POST: Questionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,TipoQuestionario")] QuestionarioViewModel QuestionarioViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(QuestionarioViewModel);
            }

            var Questionario = QuestionarioMapper.ExtractFromViewModel(QuestionarioViewModel);
            _service.Update(Questionario);

            return RedirectToAction(nameof(Details), new { id = Questionario.Id });
        }

        // GET: Questionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var QuestionarioViewModel = QuestionarioMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (QuestionarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(QuestionarioViewModel);
        }

        // POST: Questionario/Delete/5
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