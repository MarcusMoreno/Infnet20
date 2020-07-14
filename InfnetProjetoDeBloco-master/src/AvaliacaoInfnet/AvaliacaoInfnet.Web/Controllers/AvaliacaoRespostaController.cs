using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AvaliacaoInfnet.Web.Controllers
{
    public class AvaliacaoRespostaController
    {
        public readonly IAvaliacaoRespostaAppService avaliacaoRespostaApp;
        public readonly IPerguntaAppService perguntaApp;
        public readonly IEntrevistadoAppService entrevistadoApp;
        
        public AvaliacaoRespostaController(IAvaliacaoRespostaAppService avaliacaoRespostaApp, IPerguntaAppService perguntaApp, IEntrevistadoAppService entrevistadoApp)
        {
            this.avaliacaoRespostaApp = avaliacaoRespostaApp;
            this.perguntaApp = perguntaApp;
            this.entrevistadoApp = entrevistadoApp;
        }

        // GET: Entrevisatado
        public ActionResult Index()
        {
            var viewModelResponse = new List<AvaliacaoRespostaViewModel>();
            var allAvaliacaoResposta = avaliacaoRespostaApp.GetAll();
            var allPergunta = perguntaApp.GetAll().ToList();
            var allEntrevistado = entrevistadoApp.GetAll().ToList();

            foreach (var avaliacaoResposta in allAvaliacaoResposta)
            {
                viewModelResponse.Add(AvaliacaoRespostaMapper.BuildViewModelFrom(avaliacaoResposta, allPergunta));
            }

            return View(viewModelResponse);
        }
    }
}