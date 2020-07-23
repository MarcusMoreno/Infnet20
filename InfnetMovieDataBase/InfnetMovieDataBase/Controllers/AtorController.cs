using InfnetMovieDataBase.Contratos.Request;
using InfnetMovieDataBase.Contratos.Response;
using InfnetMovieDataBase.Domain;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfnetMovieDataBase.Controllers
{
    public class AtorController : Controller
    {
        private readonly IAtorRepository atorRepository;
        private readonly IFilmeRepository filmeRepository;
        private readonly IFilmeAtorRepository filmeAtorRepository;

        public AtorController(IAtorRepository pessoaRepository, IFilmeRepository filmeRepository, IFilmeAtorRepository filmeAtorRepository)
        {
            this.atorRepository = pessoaRepository;
            this.filmeRepository = filmeRepository;
            this.filmeAtorRepository = filmeAtorRepository;
        }



        [HttpGet]
        [Route("list")]
        public List<AtorResponse> GetAll()
        {
            var atores = atorRepository.ListarAtores();

            return atores.Select(x => ResponseParser.ConvertAtor(x)).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public AtorResponse Details(int id)
        {
            var ator = atorRepository.DetalharAtor(id);
            return ResponseParser.ConvertAtor(ator);
        }


        [HttpPost]
        public ActionResult Create([FromBody]AtorRequest atorRequest)
        {
            var ator = RequestParser.ConvertAtor(atorRequest);

            var atorId = atorRepository.CriarAtor(ator);
            if (ator.Filmes != null)
            {
                for (int i = 0; i < ator.Filmes.Count; i++)
                {
                    var filmeId = ator.Filmes[i].Id;
                    var filme = filmeRepository.DetalharFilme(filmeId);
                    if (filme == null) return BadRequest($"Invalid filme id {filmeId}");

                    filmeAtorRepository.CreateOrUpdateFilmeAtor(filmeId.ToString(), atorId);
                }
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(string id, [FromBody]AtorRequest   atorRequest)
        {
            //validate
            if (atorRepository.DetalharAtor(Convert.ToInt32(id)) == null) return NotFound($"Ator not found");

            var filmes = filmeRepository.ListarFilmes().ToList();
            for (int i = 0; i < atorRequest.Filmes.Count; i++)
            {
                var filme = atorRequest.Filmes[i];
                if (filmes.Exists(x => x.Id.ToString() == filme))
                {
                    return BadRequest($"Invalid filme id {filme}");
                } 
            }
            
            var ator = RequestParser.ConvertAtor(atorRequest, id);
            atorRepository.AtualizarAtor(ator);

            for (int i = 0; i < ator.Filmes.Count; i++)
            {
                var filmeId = ator.Filmes[i].Id;
                filmeAtorRepository.CreateOrUpdateFilmeAtor(filmeId.ToString(),id);
            }
            
            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            atorRepository.ExcluirAtor(id);
            return NoContent();
        }

    }
}