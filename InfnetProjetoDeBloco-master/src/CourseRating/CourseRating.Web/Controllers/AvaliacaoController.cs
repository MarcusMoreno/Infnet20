using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly IAvaliacaoAppService _service;

        public AvaliacaoController(IAvaliacaoAppService avaliacaoApp)
        {
            _service = avaliacaoApp;
        }

        // GET: Avaliacao
        public ActionResult Index() => View(_service.GetAll().Select(AvaliacaoMapper.BuildViewModelFrom));

        // GET: Avaliacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var avaliacaoViewModel = AvaliacaoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (avaliacaoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(avaliacaoViewModel);
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avaliacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,TipoAvaliacao")] AvaliacaoViewModel avaliacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(avaliacaoViewModel);
            }

            var Avaliacao = AvaliacaoMapper.ExtractFromViewModel(avaliacaoViewModel);
            _service.Add(Avaliacao);

            return RedirectToAction(nameof(Index));

        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var avaliacaoViewModel = AvaliacaoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (avaliacaoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(avaliacaoViewModel);
        }

        // POST: Avaliacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,TipoAvaliacao")] AvaliacaoViewModel avaliacaoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(avaliacaoViewModel);
            }

            var Avaliacao = AvaliacaoMapper.ExtractFromViewModel(avaliacaoViewModel);
            _service.Update(Avaliacao);

            return RedirectToAction(nameof(Details), new { id = Avaliacao.Id });
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var avaliacaoViewModel = AvaliacaoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (avaliacaoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(avaliacaoViewModel);
        }

        // POST: Avaliacao/Delete/5
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