using AutoMapper;
using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application.ViewModel;
using SistemaDeAvaliacao.Domain.Entities;
using SistemaDeAvaliacao.Domain.Interface.Service;
using SistemaDeAvaliacao.Infra.Data.Interface;
using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application
{
    public class QuestaoCategoriaAppService : ApplicationService, IQuestaoCategoriaAppService
    {
        private readonly IQuestaoCategoriaService _questaoCategoriaService;

        public QuestaoCategoriaAppService(IQuestaoCategoriaService questaoCategoriaService, IUnitOfWork uow) : base(uow)
        {
            _questaoCategoriaService = questaoCategoriaService;
        }

        public QuestaoCategoriaViewModel ObterPorId(int id)
        {
            return Mapper.Map<QuestaoCategoria, QuestaoCategoriaViewModel>(_questaoCategoriaService.FindById(id));
        }

        public IEnumerable<QuestaoCategoriaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<QuestaoCategoria>, IEnumerable<QuestaoCategoriaViewModel>>(_questaoCategoriaService.FindAll());
        }

        public QuestaoCategoriaViewModel Adicionar(QuestaoCategoriaViewModel questaoCategoriaViewModel)
        {
            var categoria = Mapper.Map<QuestaoCategoriaViewModel, QuestaoCategoria>(questaoCategoriaViewModel);

            BeginTransaction();

            questaoCategoriaViewModel = Mapper.Map<QuestaoCategoria, QuestaoCategoriaViewModel>(_questaoCategoriaService.Add(categoria));

            Commit();

            return questaoCategoriaViewModel;
        }

        public QuestaoCategoriaViewModel Atualizar(QuestaoCategoriaViewModel questaoCategoriaViewModel)
        {
            if (CategoriaPossuiQuestoes(questaoCategoriaViewModel))
                throw new Exception("Não é possível atualizar categorias associadas a questões existentes.");

            var categoria = Mapper.Map<QuestaoCategoriaViewModel, QuestaoCategoria>(questaoCategoriaViewModel);

            BeginTransaction();

            _questaoCategoriaService.Update(categoria);

            Commit();

            return questaoCategoriaViewModel;
        }

        public void Remover(int id)
        {
            var questaoViewModel = ObterPorId(id);

            if (CategoriaPossuiQuestoes(questaoViewModel))
                throw new Exception("Não é possível apagar categorias associadas a questões existentes.");

            var questaoCategoriaViewModel = Mapper.Map<QuestaoCategoria, QuestaoCategoriaViewModel>(_questaoCategoriaService.FindById(id));


            BeginTransaction();

            _questaoCategoriaService.Remove(questaoCategoriaViewModel.CategoriaId);

            Commit();
        }

        public bool CategoriaPossuiQuestoes(QuestaoCategoriaViewModel questaoCategoriaViewModel)
        {
            var questaoCategoria = Mapper.Map<QuestaoCategoriaViewModel, QuestaoCategoria>(questaoCategoriaViewModel);
            return _questaoCategoriaService.CategoriaPossuiQuestoes(questaoCategoria);
        }

        public void Dispose()
        {
            _questaoCategoriaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
