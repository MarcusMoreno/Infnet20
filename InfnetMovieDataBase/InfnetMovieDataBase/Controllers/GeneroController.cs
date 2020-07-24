using InfnetMovieDataBase.Contratos.Request;
using InfnetMovieDataBase.Contratos.Response;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfnetMovieDataBase.Controllers
{
    [Route("genero")]
    public class GeneroController : Controller
    {
        private readonly IGeneroRepository generoRepository;
        private readonly IFilmeRepository filmeRepository;
        private readonly IFilmeGeneroRepository filmeGeneroRepository;

        public GeneroController(IGeneroRepository repository, IFilmeRepository filmeRepository, IFilmeGeneroRepository filmeGeneroRepository)
        {
            this.generoRepository = repository;
            this.filmeRepository = filmeRepository;
            this.filmeGeneroRepository = filmeGeneroRepository;
        }

        [HttpGet]
        [Route("list")]
        public List<GeneroResponse> Index()
        {
            var generos = generoRepository.ListarGenero();

            return generos.Select(x => ResponseParser.ConvertGenero(x)).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public GeneroResponse Details(int id)
        {
            var genero = generoRepository.DetalharGenero(id);

            return ResponseParser.ConvertGenero(genero);
        }
        
        [HttpPost]
        public ActionResult Create([FromBody]GeneroRequest request)
        {
            var genero = RequestParser.ConvertGenero(request);

            var generoId = generoRepository.CriarGenero(genero);
            if (genero.Filmes != null)
            {
                for (int i = 0; i < genero.Filmes.Count; i++)
                {
                    var filmeId = genero.Filmes[i].Id;
                    var filme = filmeRepository.DetalharFilme(filmeId);
                    if (filme == null) return BadRequest($"Invalid filme id {filmeId}");

                    filmeGeneroRepository.CreateOrUpdateFilmeGenero(filmeId.ToString(), generoId);
                }
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(string id, [FromBody]GeneroRequest request)
        {
            //validate
            if (generoRepository.DetalharGenero(Convert.ToInt32(id)) == null) return NotFound($"Genero not found");

            var filmes = filmeRepository.ListarFilmes().ToList();
            for (int i = 0; i < request.Filmes.Count; i++)
            {
                var filme = request.Filmes[i];
                if (filmes.Exists(x => x.Id.ToString() == filme))
                {
                    return BadRequest($"Invalid filme id {filme}");
                }
            }

            var genero = RequestParser.ConvertGenero(request, id);
            generoRepository.AtualizarGenero(genero);

            for (int i = 0; i < genero.Filmes.Count; i++)
            {
                var filmeId = genero.Filmes[i].Id;
                filmeGeneroRepository.CreateOrUpdateFilmeGenero(filmeId.ToString(), id);
            }

            return NoContent();
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            generoRepository.ExcluirGenero(id);
            return NoContent();
        }
    }
}
