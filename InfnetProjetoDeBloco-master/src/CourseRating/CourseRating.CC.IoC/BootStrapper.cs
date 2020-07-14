using CourseRating.Application.Interface;
using CourseRating.Application.Services;
using CourseRating.Data.Context;
using CourseRating.Data.Repositories;
using CourseRating.Domain.Interfaces.Repositories;
using CourseRating.Domain.Interfaces.Services;
using CourseRating.Domain.Services;
using SimpleInjector;

namespace CourseRating.CC.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            //App
            container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoAppService, AvaliacaoAppService>(Lifestyle.Scoped);
            container.Register<ICursoAppService, CursoAppService>(Lifestyle.Scoped);
            container.Register<IModuloAppService, ModuloAppService>(Lifestyle.Scoped);
            container.Register<ITurmaAppService, TurmaAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IProfessorAppService, ProfessorAppService>(Lifestyle.Scoped);
            container.Register<IQuestionarioAppService, QuestionarioAppService>(Lifestyle.Scoped);
            //Domain
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);
            container.Register<IAvaliacaoService, AvaliacaoService>(Lifestyle.Scoped);
            container.Register<ICursoService, CursoService>(Lifestyle.Scoped);
            container.Register<IModuloService, ModuloService>(Lifestyle.Scoped);
            container.Register<ITurmaService, TurmaService>(Lifestyle.Scoped);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IProfessorService, ProfessorService>(Lifestyle.Scoped);
            container.Register<IQuestionarioService, QuestionarioService>(Lifestyle.Scoped);
            //Infra
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);
            container.Register<IAvaliacaoRepository, AvaliacaoRepository>(Lifestyle.Scoped);
            container.Register<ICursoRepository, CursoRepository>(Lifestyle.Scoped);
            container.Register<IModuloRepository, ModuloRepository>(Lifestyle.Scoped);
            container.Register<ITurmaRepository, TurmaRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IProfessorRepository, ProfessorRepository>(Lifestyle.Scoped);
            container.Register<IQuestionarioRepository, QuestionarioRepository>(Lifestyle.Scoped);


            container.Register<CourseRatingContext>(Lifestyle.Scoped);
        }
    }
}
