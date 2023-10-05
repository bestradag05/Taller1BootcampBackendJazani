using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
