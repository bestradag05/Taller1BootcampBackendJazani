using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Repositories;
using Taller.Domain.Cores.Paginations;
using Taller.Infraestructure.Admins.Persistence;
using Taller.Infraestructure.Cores.Paginations;

namespace Taller.Infraestructure.Cores.Context
{
    public static class InfraestructureServiceRegistration
    {
        public static IServiceCollection addInfraestructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));

            });

            services.AddTransient(typeof(IPagination<>), typeof(Paginator<>));
            

            return services;
        }

    }
}
