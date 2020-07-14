using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application.ViewModel;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeAvaliacao.MVC.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly IAvaliacaoAppService _avaliacaoAppService;
        private readonly IQuestaoAppService _questaoAppService;
        private readonly IQuestaoCategoriaAppService _questaoCategoriaAppService;
        private readonly IAvaliacaoRespostaAppService _avaliacaoRespostaAppService;

        public AvaliacaoController(IAvaliacaoAppService avaliacaoAppService, IQuestaoAppService questaoAppService, IQuestaoCategoriaAppService questaoCategoriaAppService, IAvaliacaoRespostaAppService avaliacaoRespostaAppService)
        {
            _avaliacaoAppService = avaliacaoAppService;
            _questaoAppService = questaoAppService;
            _questaoCategoriaAppService = questaoCategoriaAppService;
            _avaliacaoRespostaAppService = avaliacaoRespostaAppService;
        }

        // GET: Avaliacao
        public ActionResult Index()
        {
            return View(_avaliacaoAppService.ObterTodos());
        }

        // GET: Avaliacao/Details/5
        public ActionResult Details(int id)
        {
            return View(_avaliacaoAppService.ObterPorId(id));
        }

        // GET: Avaliacao/Create
        public ActionResult Create()
        {
            AvaliacaoViewModel avaliacaoViewModel = new AvaliacaoViewModel()
            {
                ListaQuestoes = _questaoAppService.ObterTodos().ToList(),
                ListaCategorias = _questaoCategoriaAppService.ObterTodos().ToList()
            };
            return View(avaliacaoViewModel);
        }

        // POST: Avaliacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AvaliacaoViewModel avaliacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (avaliacaoViewModel.IdQuestoesSelecionadas == null)
                        throw new Exception("Nenhuma questão selecionada.");

                    avaliacaoViewModel = _avaliacaoAppService.Adicionar(avaliacaoViewModel);

                    return RedirectToAction("Index");
                }

                return View(avaliacaoViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AvaliacaoAppService", "Adicionar"));
            }
        }

        // GET: Avaliacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            AvaliacaoViewModel avaliacaoViewModel = _avaliacaoAppService.ObterPorId(id.Value);

            if (avaliacaoViewModel == null)
                return HttpNotFound();

            avaliacaoViewModel.ListaCategorias = _questaoCategoriaAppService.ObterTodos().ToList();
            avaliacaoViewModel.ListaQuestoes = _questaoAppService.ObterTodos().ToList();

            return View(avaliacaoViewModel);
        }

        // POST: Avaliacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AvaliacaoViewModel avaliacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _avaliacaoAppService.Atualizar(avaliacaoViewModel);

                    return RedirectToAction("Details", new { id = avaliacaoViewModel.AvaliacaoId });
                }

                var questoes = _avaliacaoAppService.ObterPorId(avaliacaoViewModel.AvaliacaoId).Questoes;
                avaliacaoViewModel.ListaCategorias = _questaoCategoriaAppService.ObterTodos().ToList();
                avaliacaoViewModel.ListaQuestoes = _questaoAppService.ObterTodos().ToList();

                return View(avaliacaoViewModel);
            }
            catch (Exception ex)
            {
                var questoes = _avaliacaoAppService.ObterPorId(avaliacaoViewModel.AvaliacaoId).Questoes;
                avaliacaoViewModel.Questoes = questoes;
                avaliacaoViewModel.ListaCategorias = _questaoCategoriaAppService.ObterTodos().ToList();
                avaliacaoViewModel.ListaQuestoes = _questaoAppService.ObterTodos().ToList();
                ModelState.AddModelError("", ex.Message);
                return View(avaliacaoViewModel);
            }
        }

        public ActionResult Responder(int? matricula, Guid? codigoDeAcesso)
        {
            if (matricula == null || codigoDeAcesso == Guid.Empty)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            try
            {
                var avaliacao = _avaliacaoAppService.ObterPorCodigoDeAcesso(codigoDeAcesso.Value);

                if (avaliacao == null)
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);

                if (!_avaliacaoAppService.AvaliacaoEstaAbertaParaRespostas(avaliacao))
                    throw new Exception("O período de avaliação está encerrado.");

                if(_avaliacaoAppService.AlunoJaRespondeuAvaliacao(codigoDeAcesso.Value, matricula.Value))
                    throw new Exception("Identificamos que você já respondeu a nossa avaliação. Obrigado!");


                var ResponderAvaliacao = _avaliacaoRespostaAppService.MontarResponderAvaliacaoViewModel(codigoDeAcesso.Value, matricula.Value);
                //Consultar matricula do aluno pelo servico.

                if (ResponderAvaliacao == null)
                    return HttpNotFound();

                return View(ResponderAvaliacao);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "AvaliacaoAppService", "Responder"));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Responder(ResponderAvaliacaoViewModel responderAvaliacaoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach(var item in responderAvaliacaoViewModel.AvaliacaoRespostas)
                    {
                        if(item.Resposta == 0)
                        {
                            throw new Exception("Existem perguntas não respondidas.");
                        }
                    }

                    if (_avaliacaoRespostaAppService.Adicionar(responderAvaliacaoViewModel))
                        return RedirectToAction("AvaliacaoSucesso");
                }

                throw new Exception("Erro - Modelo inválido.");
            }
            catch (Exception ex)
            {
                var ravm = _avaliacaoRespostaAppService.MontarResponderAvaliacaoViewModel(responderAvaliacaoViewModel.CodigoAcesso, responderAvaliacaoViewModel.MatriculaAluno);
                ravm.AvaliacaoRespostas = responderAvaliacaoViewModel.AvaliacaoRespostas;
                ModelState.AddModelError("", ex.Message);
                return View(ravm);
            }
        }

        public ActionResult AvaliacaoSucesso()
        {
            return View();
        }

            // GET: Avaliacao/Delete/5
            //public ActionResult Delete(int id)
            //{
            //    return View();
            //}

            //// POST: Avaliacao/Delete/5
            //[HttpPost]
            //public ActionResult Delete(int id, FormCollection collection)
            //{
            //    try
            //    {
            //        // TODO: Add delete logic here

            //        return RedirectToAction("Index");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
        }
}
