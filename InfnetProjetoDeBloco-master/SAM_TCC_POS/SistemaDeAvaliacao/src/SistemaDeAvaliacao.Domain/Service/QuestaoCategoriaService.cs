using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Domain.Interface.Service;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeAvaliacao.Domain.Service
{
    public class QuestaoCategoriaService : ServiceBase<QuestaoCategoria>, IQuestaoCategoriaService
    {
        private readonly IQuestaoCategoriaRepository _questaoCategoriaRepository;
        private readonly IQuestaoRepository _questaoRepository;

        public QuestaoCategoriaService(IQuestaoCategoriaRepository questaoCategoriaRepository, IQuestaoRepository questaoRepository) : base(questaoCategoriaRepository)
        {
            _questaoCategoriaRepository = questaoCategoriaRepository;
            _questaoRepository = questaoRepository;
        }

        public bool CategoriaPossuiQuestoes(QuestaoCategoria questaoCategoria)
        {
            var questoes = _questaoRepository.FindAll().ToList().Where(q => q.CategoriaId == questaoCategoria.CategoriaId).ToList();
            
            if (questoes.Count > 0)
                return true;

            return false;
        }
    }
}
