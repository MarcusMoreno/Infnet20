using CourseRating.Domain.Entities;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;

namespace CourseRating.Domain.Services
{
   public  class AvaliacaoService : ServiceBase<Avaliacao>, IAvaliacaoService
    {
        private readonly IAvaliacaoRepository AvaliacaoRespository;

        public AvaliacaoService(IAvaliacaoRepository repository) : base(repository)
        {
            AvaliacaoRespository = repository;
        }
    }
}
