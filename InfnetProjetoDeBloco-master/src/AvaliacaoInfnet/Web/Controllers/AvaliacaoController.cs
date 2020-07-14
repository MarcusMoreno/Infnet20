using AvaliacaoInfnet.Application;
using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain.Mailer;
using AvaliacaoInfnet.Web.Mapper;
using AvaliacaoInfnet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        public readonly IAvaliacaoAppService avaliacaoApp;
        public readonly IPerfilAppService perfilApp;

        public AvaliacaoController(IAvaliacaoAppService avaliacaoApp)
        {
            this.avaliacaoApp = avaliacaoApp;
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            var allAvaliacao = avaliacaoApp.GetAll().ToList();
            var avaliacaoVM = new List<AvaliacaoViewModel>();

            foreach (var avaliacao in allAvaliacao)
            {
                avaliacaoVM.Add(AvaliacaoMapper.BuildViewModelFrom(avaliacao));
            }

            return View(avaliacaoVM);
        }

        // GET: Avaliacao/Details/5
        public ActionResult Details(int id)
        {
            var avaliacao = avaliacaoApp.GetById(id);
            var avaliacaoVM = AvaliacaoMapper.BuildViewModelFrom(avaliacao);
            return View(avaliacaoVM);
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avaliacao/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Descricao, Status")]AvaliacaoViewModel avaliacaoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var avaliacao = AvaliacaoMapper.ExtractFromViewModel(avaliacaoVM);
                    avaliacaoApp.Add(avaliacao);
                    return RedirectToAction(nameof(Index));
                }

                return View(avaliacaoVM);
            }
            catch (Exception)
            {
                return View(avaliacaoVM);
            }
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int id)
        {
            var avaliacao = avaliacaoApp.GetById(id);
            var avaliacaoVM = AvaliacaoMapper.BuildViewModelFrom(avaliacao);
            return View(avaliacaoVM);
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Descricao,Status")] AvaliacaoViewModel avaliacaoVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var avaliacao = AvaliacaoMapper.ExtractFromViewModel(avaliacaoVM);
                    avaliacaoApp.Update(avaliacao);
                    return RedirectToAction(nameof(Index));
                }

                return View(avaliacaoVM);
            }
            catch (Exception)
            {
                return View(avaliacaoVM);
            }
        }

        // GET: Avaliacao/Delete/5
        public ActionResult Delete(int id)
        {
            var avaliacao = avaliacaoApp.GetById(id);

            var avaliacaoVM = AvaliacaoMapper.BuildViewModelFrom(avaliacao);

            if (avaliacaoVM == null)
            {
                return HttpNotFound();
            }

            return View(avaliacaoVM);
        }

        public ActionResult Enviar(int id)
        {

            var mailer = new Mailer();

            var avaliacao = avaliacaoApp.GetById(id);

            var allPerfis = perfilApp.GetAll();

            foreach (var perfil in allPerfis)
            {
            }

            return View();
        }

        // POST: PerfilConta/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            avaliacaoApp.Remove(avaliacaoApp.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}