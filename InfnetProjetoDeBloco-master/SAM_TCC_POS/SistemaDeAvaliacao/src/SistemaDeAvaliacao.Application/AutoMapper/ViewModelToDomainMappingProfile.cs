using AutoMapper;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;

namespace SistemaDeAvaliacao.Application.AutoMapper
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<QuestaoCategoriaViewModel, QuestaoCategoria>();
            CreateMap<QuestaoViewModel, Questao>();
            CreateMap<AvaliacaoViewModel, Avaliacao>();
            CreateMap<OpcaoRespostaViewModel, OpcaoResposta>();
            CreateMap<ResponderAvaliacaoViewModel, AvaliacaoResposta>();
        }
    }
}