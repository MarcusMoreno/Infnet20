using SistemaDeAvaliacao.Application.ViewModel;
using System;

namespace SistemaDeAvaliacao.Application.Interface
{
    public interface IAvaliacaoRespostaAppService
    {
        ResponderAvaliacaoViewModel MontarResponderAvaliacaoViewModel(Guid codigoDeAcesso, int matricula);
        bool Adicionar(ResponderAvaliacaoViewModel respostas);
        bool AvaliacaoEstaAbertaParaRespostas(AvaliacaoViewModel avaliacaoViewModel);
    }
}
