using InfnetMovieDataBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfnetMovieDataBase.Contratos.Response
{
    public class ResponseParser
    {
        public static FilmeResponse ConvertFilme(Filme filme)
        {
            var filmeResponse = new FilmeResponse();

            filmeResponse.Id = filme.Id.ToString();
            filmeResponse.Titulo = filme.Titulo;
            filmeResponse.TituloOriginal = filme.TituloOriginal;
            if (filme.Genero != null)
            {
                filmeResponse.Genero = new GeneroResponse();
                filmeResponse.Genero.Descricao = filme.Genero.Descricao;
            }

            if (filme.Atores != null)
            {
                filmeResponse.Atores = new List<AtorResponse>();
                foreach (var ator in filme.Atores)
                {
                    filmeResponse.Atores.Add(new AtorResponse() { Nome = ator.Nome, Sobrenome = ator.Sobrenome });
                }
            }

            return filmeResponse;
        }

        public static AtorResponse ConvertAtor(Ator  ator)
        {
            var atorResponse = new AtorResponse();

            atorResponse.Id = ator.Id.ToString();
            atorResponse.Nome = ator.Nome;
            atorResponse.Sobrenome = ator.Sobrenome;
           

            if (ator.Filmes != null)
            {
                atorResponse.Filmes = new List<FilmeResponse>();
                foreach (var filme in ator.Filmes)
                {
                    atorResponse.Filmes.Add(new FilmeResponse() { Titulo = filme.Titulo, TituloOriginal = filme.TituloOriginal });
                }
            }

            return atorResponse;
        }

        public static GeneroResponse ConvertGenero(Genero genero)
        {
            var generoResponse = new GeneroResponse();
            generoResponse.Id = genero.Id.ToString();
            generoResponse.Descricao = genero.Descricao;

            if(genero.Filmes != null)
            {
                generoResponse.Filmes = new List<FilmeResponse>();
                
                foreach(var filme in genero.Filmes)
                {
                    generoResponse.Filmes.Add(new FilmeResponse() { Titulo = filme.Titulo, TituloOriginal = filme.TituloOriginal });
                }
            }
            return generoResponse;
        }
    }
}
