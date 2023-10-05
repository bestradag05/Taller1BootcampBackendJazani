using Autofac;
using System.Reflection;

namespace Taller.Infraestructure.Cores.Context
{
    public class InfraestructureAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
