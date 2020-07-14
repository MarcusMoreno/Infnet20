using Autofac;


namespace IoC
{
    public class IoCModulo : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            IoCConfig.Load(builder);
        }
    }
}
