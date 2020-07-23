using InfnetMovieDataBase.Domain;
using System;
using System.Collections.Generic;

namespace InfnetMovieDataBase.Contratos.Request
{
    public class RequestParser
    {
        public static Filme ConvertFilme(FilmeRequest filme, string filmeId = null)
        {
            var filmeResponse = new Filme();
            if (!string.IsNullOrEmpty(filmeId)) filmeResponse.Id = Convert.ToInt32(filmeId);

            filmeResponse.Titulo = filme.Titulo;
            filmeResponse.TituloOriginal = filme.TituloOriginal;
            if(!string.IsNullOrEmpty(filme.Genero))
            {
                filmeResponse.Genero = new Genero();
                filmeResponse.Genero.Id = Convert.ToInt32(filme.Genero);
            }

            if (filme.Atores != null)
            {
                filmeResponse.Atores = new List<Ator>();
                foreach (var ator in filme.Atores)
                {
                    filmeResponse.Atores.Add(new Ator() { Id = Convert.ToInt32(ator) });
                }
            }

            return filmeResponse;
        }

        public static Ator ConvertAtor(AtorRequest atorRequest, string atorId = null)
        {
            var ator = new Ator();
            if (!string.IsNullOrEmpty(atorId)) ator.Id = Convert.ToInt32(atorId);
            ator.Nome = atorRequest.Nome;
            ator.Sobrenome = atorRequest.Sobrenome;


            if (atorRequest.Filmes != null)
            {
                ator.Filmes = new List<Filme>();
                foreach (var filme in atorRequest.Filmes)
                {
                    ator.Filmes.Add(new Filme() { Id = Convert.ToInt32(filme) });
                }
            }

            return ator;
        }
    }
}
