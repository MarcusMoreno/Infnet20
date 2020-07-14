using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Web.Mapper;
using AvaliacaoInfnet.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Controllers
{
    public class PerguntaController : Controller
    {
        public readonly IPerguntaAppService perguntaApp;
        public readonly ITipoRespostaAppService tipoRespostaApp;

        public PerguntaController(IPerguntaAppService perguntaApp, ITipoRespostaAppService tipoRespostaApp)
        {
            this.perguntaApp = perguntaApp;
            this.tipoRespostaApp = tipoRespostaApp;
        }

        public ActionResult Index()
        {
            var allPerguntas = perguntaApp.GetAll().ToList();
            var allTipoRespostas = tipoRespostaApp.GetAll().ToList();
            var perguntas = new List<PerguntaViewModel>();           

            for (int i = 0; i < allPerguntas.Count; i++)
            {
                perguntas.Add(PerguntaMapper.BuildViewModelFrom(allPerguntas[i], allTipoRespostas));
            }

            return View(perguntas);
        }

        public ActionResult Details(int id)
        {
            var allTipoRespostas = tipoRespostaApp.GetAll().ToList();
            var viewModelResponse = PerguntaMapper.BuildViewModelFrom(perguntaApp.GetById(id), allTipoRespostas);
            return View(viewModelResponse);
        }

        // GET: Pergunta/Create
        public ActionResult Create()
        {
            var tipoRespostaList = new List<SelectListItem>();
            var allTipoResposta = tipoRespostaApp.GetAll();

            foreach (var tipoResposta in allTipoResposta)
            {
                tipoRespostaList.Add(new SelectListItem
                {
                    Text = tipoResposta.Descricao,
                    Selected = false,
                    Value = tipoResposta.Id.ToString(),
                });
            }

            ViewBag.TipoRespostaList = tipoRespostaList;

            return View();
        }

        // POST: PErgunta/Create
        [HttpPost]
        public ActionResult Create(PerguntaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    perguntaApp.Add(PerguntaMapper.ExtractFromViewModel(viewModel));
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int id)
        {
            var pergunta = perguntaApp.GetById(id);
            var viewModelResponse = PerguntaMapper.BuildViewModelFrom(pergunta, null);

            return View(viewModelResponse);
        }

        // POST: Pergunta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PerguntaViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var pergunta = PerguntaMapper.ExtractFromViewModel(viewModel);
                    pergunta.Id = id;
                    perguntaApp.Update(pergunta);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModelResponse = PerguntaMapper.BuildViewModelFrom(perguntaApp.GetById(id), null);

            return View(viewModelResponse);
        }

        // POST: Pergunta/Delete/5
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    perguntaApp.Remove(perguntaApp.GetById(id));

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        //public ActionResult Edit(int? id)
        //{
        //    var allTipoRespostas = tipoRespostaApp.GetAll().ToList();

        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var perguntaViewModel = PerguntaMapper.BuildViewModelFrom(perguntaApp.GetById(id.Value), allTipoRespostas);

        //    if (perguntaViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(perguntaViewModel);
        //}

        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Descricao,Status,Perguntas")] PerguntaViewModel perguntaViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var pergunta = PerguntaMapper.ExtractFromViewModel(perguntaViewModel);
        //        perguntaApp.Update(pergunta);

        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(perguntaViewModel);
        //}

        //// GET: Perfil/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var pergunta = perguntaApp.GetById(id.Value);

        //    var perguntaViewModel = PerguntaMapper.BuildViewModelFrom(pergunta);

        //    if (perguntaViewModel == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(perguntaViewModel);
        //}

        //// POST: Perfil/Delete/5
        //[HttpPost, ActionName(nameof(Delete))]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    perguntaApp.Remove(perguntaApp.GetById(id));
        //    return RedirectToAction(nameof(Index));
        //}
    }
}