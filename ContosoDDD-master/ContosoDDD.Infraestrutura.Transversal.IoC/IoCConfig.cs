using Autofac;
using ContosoDDD.Aplicacao.Interfaces;
using ContosoDDD.Aplicacao.Servicos;
using ContosoDDD.Dominio.Interfaces.Repositorios;
using ContosoDDD.Dominio.Interfaces.Servicos;
using ContosoDDD.Dominio.Servicos;
using ContosoDDD.Infraestrutura.Persistencia.Repositorio;
using ContosoDDD.Infraestrutura.Transversal.AutoMapper;

namespace ContosoDDD.Infraestrutura.Transversal.IoC
{
    public class IoCConfig
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AlunoServicoAplicacao>().As<IAlunoServicoAplicacao>();

            builder.RegisterType<AlunoServicoDominio>().As<IAlunoServicoDominio>();

            builder.RegisterType<AlunoRepositorio>().As<IAlunoRepositorio>();

            builder.RegisterType<MapperAluno>().As<IMapperAluno>();
        }
    }
}
