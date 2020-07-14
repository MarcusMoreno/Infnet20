using AutoMapper;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Service;
using SistemaDeAvaliacao.Infra.Data.Interface;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application
{
    public class OpcaoRespostaAppService :ApplicationService
    {
        private readonly IOpcaoRespostaService _opcaoRespostaService;

        public OpcaoRespostaAppService(IOpcaoRespostaService opcaoRespostaService, IUnitOfWork uow) : base(uow)
        {
            _opcaoRespostaService = opcaoRespostaService;
        }

        public IEnumerable<OpcaoRespostaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<OpcaoResposta>, IEnumerable<OpcaoRespostaViewModel>>(_opcaoRespostaService.FindAll());
        }
    }
}
