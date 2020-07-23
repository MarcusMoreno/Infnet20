using InfnetMovieDataBase.Contratos.Request;
using InfnetMovieDataBase.Contratos.Response;
using InfnetMovieDataBase.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfnetMovieDataBase.Controllers
{
    [Route("filme")]
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository filmeRepository;
        private readonly IAtorRepository atorRepository;
        private readonly IFilmeAtorRepository filmeAtorRepository;
        private readonly IGeneroRepository generoRepository;
        private readonly IFilmeGeneroRepository filmeGeneroRepository;

        public FilmeController(IFilmeRepository filmeRepository, IAtorRepository atorRepository, IFilmeAtorRepository filmeAtorRepository, IGeneroRepository generoRepository, IFilmeGeneroRepository filmeGeneroRepository)
        {
            this.filmeRepository = filmeRepository;
            this.atorRepository = atorRepository;
            this.filmeAtorRepository = filmeAtorRepository;
            this.generoRepository = generoRepository;
            this.filmeGeneroRepository = filmeGeneroRepository;
        }

        [HttpGet]
        [Route("list")]
        public List<FilmeResponse> GetAll()
        {
            var filmes = filmeRepository.ListarFilmes();

            return filmes.Select(x => ResponseParser.ConvertFilme(x)).ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public FilmeResponse Details(int id)
        {
            var filme = filmeRepository.DetalharFilme(id);
            return ResponseParser.ConvertFilme(filme);
        }

        [HttpPost]
        public ActionResult Create([FromBody]FilmeRequest filmeRequest)
        {
            var filme = RequestParser.ConvertFilme(filmeRequest);

            var filmeId = filmeRepository.CriarFilme(filme);
            if (filme.Atores != null)
            {
                for (int i = 0; i < filme.Atores.Count; i++)
                {
                    var atorId = filme.Atores[i].Id;
                    var ator = atorRepository.DetalharAtor(atorId);
                    if (ator == null) return BadRequest($"Invalid ator id {atorId}");

                    filmeAtorRepository.CreateOrUpdateFilmeAtor(filmeId, atorId.ToString());
                }
            }
            if (filme.Genero != null)
            {
                var generoId = filme.Genero.Id;
                var genero = generoRepository.DetalharGenero(generoId);
                if (genero == null) return BadRequest($"Invalid genero id {generoId}");

                filmeGeneroRepository.CreateOrUpdateFilmeGenero(filmeId, filme.Id.ToString()); ;
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit(string id, [FromBody]FilmeRequest filmeRequest)
        {
            if(filmeRepository.DetalharFilme(Convert.ToInt32(id)) == null) return NotFound($"Filme not found");

            if (filmeRequest.Atores != null)
            {
                var atores = atorRepository.ListarAtores().ToList();
                for (int i = 0; i < filmeRequest.Atores.Count; i++)
                {
                    var ator = filmeRequest.Atores[i];
                    if (atores.Exists(x => x.Id.ToString() == ator))
                    {
                        return BadRequest($"Invalid ator id {ator}");
                    }
                }
            }
            if (string.IsNullOrEmpty(filmeRequest.Genero))
            {
                var genero = generoRepository.DetalharGenero(Convert.ToInt32(filmeRequest.Genero));
                if (genero == null) return BadRequest($"Invalid genero id {filmeRequest.Genero}");
            }

            var filme = RequestParser.ConvertFilme(filmeRequest, id);


            filmeRepository.AtualizarFilme(filme);
            for (int i = 0; i < filme.Atores.Count; i++)
            {
                var atorId = filme.Atores[i].Id;
                filmeAtorRepository.CreateOrUpdateFilmeAtor(filme.Id.ToString(), atorId.ToString());
            }
            if (filme.Genero != null)
            {
                var generoId = filme.Genero.Id;
                filmeGeneroRepository.CreateOrUpdateFilmeGenero(filme.Id.ToString(), filme.Id.ToString());
            }
   
            return NoContent();
        }
        
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            filmeRepository.ExcluirFilme(id);
            return NoContent();
        }
    }
}