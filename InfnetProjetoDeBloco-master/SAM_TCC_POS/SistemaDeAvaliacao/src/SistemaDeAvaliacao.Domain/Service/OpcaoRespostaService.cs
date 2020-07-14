using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class OpcaoRespostaService : ServiceBase<OpcaoResposta>, IOpcaoRespostaService
    {
        private readonly IOpcaoRespostaRepository _opcaoRespostaRepository;

        public OpcaoRespostaService(IOpcaoRespostaRepository opcaoRespostaRepository) : base(opcaoRespostaRepository)
        {
            _opcaoRespostaRepository = opcaoRespostaRepository;
        }
    }
}
