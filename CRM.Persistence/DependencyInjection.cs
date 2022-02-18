using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CRM.Application.Interfaces;

namespace CRM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<CRM_DbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<ICRM_DbContext>(provider =>
                provider.GetService<CRM_DbContext>());
            return services;
        }
    }
}
