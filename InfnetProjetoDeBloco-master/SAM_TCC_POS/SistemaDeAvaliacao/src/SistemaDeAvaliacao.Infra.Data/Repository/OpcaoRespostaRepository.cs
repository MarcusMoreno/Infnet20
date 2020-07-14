using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class OpcaoRespostaRepository : RepositoryBase<OpcaoResposta>, IOpcaoRespostaRepository
    {
        public OpcaoRespostaRepository(SistemaDeAvaliacaoDbContext context) : base(context)
        {
        }
    }
}
