using Autofac;
using AvaliacaoInfnet.Application;
using AvaliacaoInfnet.Application.Interface;
using AvaliacaoInfnet.Domain.Interfaces.Repositorio;
using AvaliacaoInfnet.Domain.Interfaces.Service;
using AvaliacaoInfnet.Domain.Services;
using AvaliacaoInfnet.Persistencia.Repository;

namespace IoC
{
    public class IoCConfig
    {
        public static void Load(ContainerBuilder builder)
        {
            //App
            builder.RegisterType<AvaliacaoAppService>().As<IAvaliacaoAppService>();
            builder.RegisterType<PerfilAppService>().As<IPerfilAppService>();
            builder.RegisterType<PerguntaAppService>().As<IPerguntaAppService>();
            builder.RegisterType<EntrevistadoAppService>().As<IEntrevistadoAppService>();
            builder.RegisterType<TipoRespostaAppService>().As<ITipoRespostaAppService>();


            //Domain
            builder.RegisterType<AvaliacaoService>().As<IAvaliacaoService>();
            builder.RegisterType<PerguntaService>().As<IPerguntaService>();
            builder.RegisterType<PerfilService>().As<IPerfilService>();
            builder.RegisterType<EntrevistadoService>().As<IEntrevistadoService>();
            builder.RegisterType<TipoRespostaService>().As<ITipoRespostaService>();

            //Infra
            builder.RegisterType<AvaliacaoRepository>().As<IAvaliacaoRepository>();
            builder.RegisterType<PerguntaRepository>().As<IPerguntaRepository>();
            builder.RegisterType<PerfilRepository>().As<IPerfilRepository>();
            builder.RegisterType<EntrevistadoRepository>().As<IEntrevistadoRepository>();
            builder.RegisterType<TipoRespostaRepository>().As<ITipoRespostaRepository>();


        }
    }
}
