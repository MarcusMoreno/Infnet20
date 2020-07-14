using SistemaDeAvaliacao.Domain.Interface.Repository;
using SistemaDeAvaliacao.Infra.CrossCutting.Identity.Configuration;
using SistemaDeAvaliacao.Infra.CrossCutting.Identity.Context;
using SistemaDeAvaliacao.Infra.CrossCutting.Identity.Model;
using SistemaDeAvaliacao.Infra.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SistemaDeAvaliacao.Infra.Data.Interface;
using SistemaDeAvaliacao.Infra.Data.UoW;
using SistemaDeAvaliacao.Infra.Data.Context;
using SistemaDeAvaliacao.Domain.Interface.Service;
using SistemaDeAvaliacao.Domain.Service;
using SistemaDeAvaliacao.Application.Interface;
using SistemaDeAvaliacao.Application;

namespace SistemaDeAvaliacao.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            //Application
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IQuestaoCategoriaAppService, QuestaoCategoriaAppService>(Lifestyle.Scoped);
            container.Register<IQuestaoAppService, QuestaoAppService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoAppService, AvaliacaoAppService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoRespostaAppService, AvaliacaoRespostaAppService>(Lifestyle.Scoped);

            //Domain
            container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IQuestaoCategoriaService, QuestaoCategoriaService>(Lifestyle.Scoped);
            container.Register<IQuestaoService, QuestaoService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoService, AvaliacaoService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoRespostaService, AvaliacaoRespostaService>(Lifestyle.Scoped);
            container.Register<IOpcaoRespostaService, OpcaoRespostaService>(Lifestyle.Scoped);

            //Repository
            container.Register<SistemaDeAvaliacaoDbContext>(Lifestyle.Scoped);
            container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IQuestaoCategoriaRepository, QuestaoCategoriaRepository>(Lifestyle.Scoped);
            container.Register<IQuestaoRepository, QuestaoRepository>(Lifestyle.Scoped);
            container.Register<IAvaliacaoRepository, AvaliacaoRepository>(Lifestyle.Scoped);
            container.Register<IAvaliacaoRespostaRepository, AvaliacaoRespostaRepository>(Lifestyle.Scoped);
            container.Register<IOpcaoRespostaRepository, OpcaoRespostaRepository>(Lifestyle.Scoped);
        } 
    }
}