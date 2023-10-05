using Autofac;
using System.Reflection;

namespace Taller.Application.Cores.Context
{
    public class AplicationAutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces() // que implemente las interfaces
            .InstancePerLifetimeScope(); // indicamos el alcance
        }
    }
}
