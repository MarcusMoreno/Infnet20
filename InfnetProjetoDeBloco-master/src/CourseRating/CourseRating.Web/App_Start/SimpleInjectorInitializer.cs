[assembly: WebActivator.PostApplicationStartMethod(typeof(CourseRating.Web.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace CourseRating.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using CourseRating.CC.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            BootStrapper.RegisterServices(container);

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}