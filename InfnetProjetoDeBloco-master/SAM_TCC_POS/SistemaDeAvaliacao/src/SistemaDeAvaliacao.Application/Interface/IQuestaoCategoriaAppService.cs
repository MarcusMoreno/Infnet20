using SistemaDeAvaliacao.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application.Interface
{
    public interface IQuestaoCategoriaAppService : IDisposable
    {
        QuestaoCategoriaViewModel ObterPorId(int id);
        IEnumerable<QuestaoCategoriaViewModel> ObterTodos();
        QuestaoCategoriaViewModel Adicionar(QuestaoCategoriaViewModel questaoCategoriaViewModel);
        QuestaoCategoriaViewModel Atualizar(QuestaoCategoriaViewModel questaoCategoriaViewModel);
        void Remover(int id);
    }
}
