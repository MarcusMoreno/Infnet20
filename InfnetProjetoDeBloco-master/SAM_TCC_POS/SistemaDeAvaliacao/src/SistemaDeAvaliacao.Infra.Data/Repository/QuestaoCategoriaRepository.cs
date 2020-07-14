using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class QuestaoCategoriaRepository : RepositoryBase<QuestaoCategoria>, IQuestaoCategoriaRepository
    {
        public QuestaoCategoriaRepository(SistemaDeAvaliacaoDbContext context) : base(context)
        {
        }
    }
}
