using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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
