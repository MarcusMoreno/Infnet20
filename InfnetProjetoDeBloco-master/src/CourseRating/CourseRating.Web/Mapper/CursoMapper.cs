using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRating.Web.Mapper
{
    public class CursoMapper
    {
        public static Curso ExtractFromViewModel(CursoViewModel viewModel)
        {
            var curso = new Curso
            {
                Id = viewModel.Id,
                Nome = viewModel.Nome,
                Blocos = viewModel.Blocos
                //TODO Adicionar todos os atributos
            };
            return curso;
        }


        public static CursoViewModel BuildViewModelFrom(Curso curso)
        {
            var viewModel = new CursoViewModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Blocos = curso.Blocos
                //TODO Adicionar todos os atributos
            };

            return viewModel;
        }
    }
}