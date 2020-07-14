using SistemaDeAvaliacao.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace SistemaDeAvaliacao.Application.Interface
{
    public interface IAvaliacaoAppService : IDisposable
    {
        AvaliacaoViewModel ObterPorId(int id);
        AvaliacaoViewModel ObterPorCodigoDeAcesso(Guid codigoDeAcesso);
        IEnumerable<AvaliacaoViewModel> ObterTodos();
        AvaliacaoViewModel Adicionar(AvaliacaoViewModel avaliacaoViewModel);
        AvaliacaoViewModel Atualizar(AvaliacaoViewModel avaliacaoViewModel);
        bool AvaliacaoEstaAbertaParaRespostas(AvaliacaoViewModel avaliacaoViewModel);
        bool AlunoJaRespondeuAvaliacao(Guid codigoDeAcesso, int matricula);
        void Remover(int id);
    }
}
