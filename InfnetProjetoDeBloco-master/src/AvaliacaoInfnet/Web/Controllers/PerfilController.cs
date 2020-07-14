using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Web.Mapper;
using AvaliacaoInfnet.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilAppService perfilApp;

        public PerfilController(IPerfilAppService perfilApp)
        {
            this.perfilApp = perfilApp;
        }

        // GET: Perfil
        public ActionResult Index()
        {
            var allPerfis = perfilApp.GetAll().ToList();
            var perfilViewModel = new List<PerfilViewModel>();

            for (int i = 0; i < allPerfis.Count; i++)
            {
                perfilViewModel.Add(PerfilMapper.BuildViewModelFrom(allPerfis[i]));
            }

            return View(perfilViewModel);
        }

        // GET: Perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var perfil = perfilApp.GetById(id.Value);
            var perfilViewModel = PerfilMapper.BuildViewModelFrom(perfil);

            if (perfil == null)
            {
                return HttpNotFound();
            }

            return View(perfilViewModel);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Perfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descricao,Status")] PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                var perfil = PerfilMapper.ExtractFromViewModel(perfilViewModel);
                perfilApp.Add(perfil);
                return RedirectToAction(nameof(Index));
            }
            return View(perfilViewModel);
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var perfilViewModel = PerfilMapper.BuildViewModelFrom(perfilApp.GetById(id.Value));

            if (perfilViewModel == null)
            {
                return HttpNotFound();
            }

            return View(perfilViewModel);
        }

        // POST: Perfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Descricao,Status,ReferenceId")] PerfilViewModel perfilViewModel)
        {
            if (ModelState.IsValid)
            {
                var perfil = PerfilMapper.ExtractFromViewModel(perfilViewModel);
                perfilApp.Update(perfil);

                return RedirectToAction(nameof(Index));
            }
            return View(perfilViewModel);
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var perfil = perfilApp.GetById(id.Value);

            var perfilViewModel = PerfilMapper.BuildViewModelFrom(perfil);

            if (perfilViewModel == null)
            {
                return HttpNotFound();
            }

            return View(perfilViewModel);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            perfilApp.Remove(perfilApp.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}