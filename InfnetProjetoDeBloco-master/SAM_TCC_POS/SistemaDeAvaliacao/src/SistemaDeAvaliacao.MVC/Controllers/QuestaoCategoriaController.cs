using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeAvaliacao.MVC.Controllers
{
    public class QuestaoCategoriaController : Controller
    {
        private readonly IQuestaoCategoriaAppService _questaoCategoriaAppService;

        public QuestaoCategoriaController(IQuestaoCategoriaAppService questaoCategoriaAppService)
        {
            _questaoCategoriaAppService = questaoCategoriaAppService;
        }

        // GET: QuestaoCategoria
        public ActionResult Index()
        {
            return View(_questaoCategoriaAppService.ObterTodos());
        }

        // GET: QuestaoCategoria/Details/5
        public ActionResult Details(int id)
        {
            return View(_questaoCategoriaAppService.ObterPorId(id));
        }

        // GET: QuestaoCategoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestaoCategoria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestaoCategoriaViewModel questaoCategoriaViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    questaoCategoriaViewModel = _questaoCategoriaAppService.Adicionar(questaoCategoriaViewModel);
                    return RedirectToAction("Index");
                }

                return View(questaoCategoriaViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "QuestaoCategoriaAppService", "Adicionar"));
            }
        }

        // GET: QuestaoCategoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestaoCategoriaViewModel questaoCategoriaViewModel = _questaoCategoriaAppService.ObterPorId(id.Value);

            if (questaoCategoriaViewModel == null)
            {
                return HttpNotFound();
            }

            return View(questaoCategoriaViewModel);
        }

        // POST: QuestaoCategoria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestaoCategoriaViewModel questaoCategoriaViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _questaoCategoriaAppService.Atualizar(questaoCategoriaViewModel);
                    return RedirectToAction("Index");
                }

                return View(questaoCategoriaViewModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(questaoCategoriaViewModel);
            }
        }

        // GET: QuestaoCategoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            QuestaoCategoriaViewModel questaoCategoriaViewModel = _questaoCategoriaAppService.ObterPorId(id.Value);

            if (questaoCategoriaViewModel == null)
                return HttpNotFound();

            return View(questaoCategoriaViewModel);
        }

        // POST: QuestaoCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int id)
        {
            try
            {
                _questaoCategoriaAppService.Remover(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                QuestaoCategoriaViewModel questaoCategoriaViewModel = _questaoCategoriaAppService.ObterPorId(id);
                ModelState.AddModelError("", ex.Message);
                return View(questaoCategoriaViewModel);
            }
        }
    }
}
