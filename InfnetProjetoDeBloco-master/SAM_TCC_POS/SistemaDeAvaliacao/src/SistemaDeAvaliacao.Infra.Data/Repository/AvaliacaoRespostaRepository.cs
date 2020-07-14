using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.Data.Context;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Infra.Data.Repository
{
    public class AvaliacaoRespostaRepository : RepositoryBase<AvaliacaoResposta>, IAvaliacaoRespostaRepository
    {
        public AvaliacaoRespostaRepository(SistemaDeAvaliacaoDbContext context) : base(context)
        {
        }

        public bool Add(IEnumerable<AvaliacaoResposta> avaliacaoRespostas)
        {
            foreach(var av in avaliacaoRespostas)
            {
                Add(av);
            }

            return true;
        }
    }
}
