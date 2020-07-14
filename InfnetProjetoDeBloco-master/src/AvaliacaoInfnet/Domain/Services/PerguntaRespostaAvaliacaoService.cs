using AvaliacaoInfnet.Domain.Interfaces;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;

namespace AvaliacaoInfnet.Domain.Services
{
    public class PerguntaRespostaAvaliacaoService : ServiceBase<PerguntaRespostaAvaliacao>
    {
        private readonly IPerguntaRespostaAvaliacaoRepository PerguntaResposta;

        public PerguntaRespostaAvaliacaoService(IPerguntaRespostaAvaliacaoRepository repository) : base(repository)
        {
            PerguntaResposta = repository;
        }

        
    }
}
