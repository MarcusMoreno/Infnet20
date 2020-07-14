using AutoMapper;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;

namespace SistemaDeAvaliacao.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<QuestaoCategoria, QuestaoCategoriaViewModel>();
            CreateMap<Questao, QuestaoViewModel>();
            CreateMap<Avaliacao, AvaliacaoViewModel>();
            CreateMap<OpcaoResposta, OpcaoRespostaViewModel>();
        }
    }
}