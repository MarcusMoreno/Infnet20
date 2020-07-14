using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class ModuloController : Controller
    {
        private readonly IModuloAppService _service;

        public ModuloController(IModuloAppService moduloApp)
        {
            _service = moduloApp;
        }

        // GET: Modulo
        public ActionResult Index() => View(_service.GetAll().Select(ModuloMapper.BuildViewModelFrom));

        // GET: Modulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ModuloViewModel = ModuloMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (ModuloViewModel == null)
            {
                return HttpNotFound();
            }
            return View(ModuloViewModel);
        }

        // GET: Modulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,TipoModulo")] ModuloViewModel ModuloViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ModuloViewModel);
            }

            var Modulo = ModuloMapper.ExtractFromViewModel(ModuloViewModel);
            _service.Add(Modulo);

            return RedirectToAction(nameof(Index));

        }

        // GET: Modulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ModuloViewModel = ModuloMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (ModuloViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ModuloViewModel);
        }

        // POST: Modulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,TipoModulo")] ModuloViewModel ModuloViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(ModuloViewModel);
            }

            var Modulo = ModuloMapper.ExtractFromViewModel(ModuloViewModel);
            _service.Update(Modulo);

            return RedirectToAction(nameof(Details), new { id = Modulo.Id });
        }

        // GET: Modulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var ModuloViewModel = ModuloMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (ModuloViewModel == null)
            {
                return HttpNotFound();
            }

            return View(ModuloViewModel);
        }

        // POST: Modulo/Delete/5
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