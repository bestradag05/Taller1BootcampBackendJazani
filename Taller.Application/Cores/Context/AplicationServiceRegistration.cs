using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Taller.Application.Admins.Services;
using Taller.Application.Admins.Services.Implementations;

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
