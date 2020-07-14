using CourseRating.Domain.Entities;
using CourseRating.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseRating.Web.Mapper
{
    public class QuestionarioMapper
    {
        public static Questionario ExtractFromViewModel(QuestionarioViewModel viewModel)
        {
            var Questionario = new Questionario
            {
                Id = viewModel.Id,
                Detalhe = viewModel.Detalhe,
                Questionarios = viewModel.Questionarios

            };

            return Questionario;
        }

        public static QuestionarioViewModel BuildViewModelFrom(Questionario Questionario)
        {
            var viewModel = new QuestionarioViewModel
            {
                Id = Questionario.Id,
                Detalhe = Questionario.Detalhe,
                Questionarios = Questionario.Questionarios
            };

            return viewModel;
        }
    }
}