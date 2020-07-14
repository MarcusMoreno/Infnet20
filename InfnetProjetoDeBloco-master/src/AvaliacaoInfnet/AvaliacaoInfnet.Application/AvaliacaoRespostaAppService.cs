using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain;
using AvaliacaoInfnet.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoInfnet.Application
{
    public class AvaliacaoRespostaAppService : AppServiceBase<AvaliacaoResposta>, IAvaliacaoRespostaAppService
    {
        private readonly IAvaliacaoRespostaService AvaliacaoRespostaService;

        public AvaliacaoRespostaAppService(IAvaliacaoRespostaService serviceBase) : base(serviceBase)
        {
            AvaliacaoRespostaService = serviceBase;
        }
    }
}

