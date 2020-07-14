using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class QuestaoRepository : RepositoryBase<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(SistemaDeAvaliacaoDbContext context) : base(context)
        {
        }
    }
}
