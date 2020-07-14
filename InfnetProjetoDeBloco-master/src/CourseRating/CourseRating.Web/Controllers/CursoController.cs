using CourseRating.Application.Interface;
using CourseRating.Web.Mapper;
using CourseRating.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CourseRating.Web.Controllers
{
    public class CursoController : Controller
    {
        private readonly ICursoAppService _service;

        public CursoController(ICursoAppService cursoApp)
        {
            _service = cursoApp;
        }

        // GET: curso
        public ActionResult Index() => View(_service.GetAll().Select(CursoMapper.BuildViewModelFrom));

        // GET: curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CursoViewModel = CursoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (CursoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(CursoViewModel);
        }

        // GET: curso/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha,Tipocurso")] CursoViewModel CursoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(CursoViewModel);
            }

            var curso = CursoMapper.ExtractFromViewModel(CursoViewModel);
            _service.Add(curso);

            return RedirectToAction(nameof(Index));

        }

        // GET: curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CursoViewModel = CursoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (CursoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(CursoViewModel);
        }

        // POST: curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha,Tipocurso")] CursoViewModel CursoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(CursoViewModel);
            }

            var curso = CursoMapper.ExtractFromViewModel(CursoViewModel);
            _service.Update(curso);

            return RedirectToAction(nameof(Details), new { id = curso.Id });
        }

        // GET: curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var CursoViewModel = CursoMapper.BuildViewModelFrom(_service.GetById(id.Value));

            if (CursoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(CursoViewModel);
        }

        // POST: curso/Delete/5
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