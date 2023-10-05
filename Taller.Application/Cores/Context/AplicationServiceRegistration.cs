using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Taller.Application.Cores.Context
{
    public static class AplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            return services;
        }
    }
}
