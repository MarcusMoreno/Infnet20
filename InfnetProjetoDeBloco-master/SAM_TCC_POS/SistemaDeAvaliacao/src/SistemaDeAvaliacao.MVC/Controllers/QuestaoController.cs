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
    public class QuestaoController : Controller
    {
        private readonly IQuestaoAppService _questaoAppService;
        private readonly IQuestaoCategoriaAppService _questaoCategoriaAppService;

        public QuestaoController(IQuestaoAppService questaoAppService, IQuestaoCategoriaAppService questaoCategoriaAppService)
        {
            _questaoAppService = questaoAppService;
            _questaoCategoriaAppService = questaoCategoriaAppService;
        }

        // GET: Questao
        public ActionResult Index()
        {
            return View(_questaoAppService.ObterTodos());
        }

        // GET: Questao/Details/5
        public ActionResult Details(int id)
        {
            return View(_questaoAppService.ObterPorId(id));
        }

        // GET: Questao/Create
        public ActionResult Create()
        {
            QuestaoViewModel questao = new QuestaoViewModel()
            {
                ListaDeCategorias = _questaoCategoriaAppService.ObterTodos()
            };

            return View(questao);
        }

        // POST: Questao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestaoViewModel questaoViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    questaoViewModel = _questaoAppService.Adicionar(questaoViewModel);
                    return RedirectToAction("Index");
                }

                questaoViewModel.ListaDeCategorias = _questaoCategoriaAppService.ObterTodos();

                return View(questaoViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "QuestaoAppService", "Adicionar"));
            }
        }

        // GET: Questao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            QuestaoViewModel questaoViewModel = _questaoAppService.ObterPorId(id.Value);

            if (questaoViewModel == null)
                return HttpNotFound();
            
            questaoViewModel.ListaDeCategorias = _questaoCategoriaAppService.ObterTodos();

            return View(questaoViewModel);
        }

        // POST: Questao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestaoViewModel questaoViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    _questaoAppService.Atualizar(questaoViewModel);
                    return RedirectToAction("Index");
                }

                questaoViewModel.ListaDeCategorias = _questaoCategoriaAppService.ObterTodos();

                return View(questaoViewModel);
            }
            catch (Exception ex)
            {
                questaoViewModel.ListaDeCategorias = _questaoCategoriaAppService.ObterTodos();
                ModelState.AddModelError("", ex.Message);
                return View(questaoViewModel);
            }
        }

        // GET: Questao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestaoViewModel questaoViewModel = _questaoAppService.ObterPorId(id.Value);

            if (questaoViewModel == null)
                return HttpNotFound();

            return View(questaoViewModel);
        }

        // POST: Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAction(int id)
        {
            try
            {
                _questaoAppService.Remover(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                QuestaoViewModel questaoViewModel = _questaoAppService.ObterPorId(id);
                ModelState.AddModelError("", ex.Message);
                return View(questaoViewModel);
            }
        }
    }
}
