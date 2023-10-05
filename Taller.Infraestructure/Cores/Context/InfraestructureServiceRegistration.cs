using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Domain.Admins.Repositories;
using Taller.Infraestructure.Admins.Persistence;

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

          

            return services;
        }

    }
}
