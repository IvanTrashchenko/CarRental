using CarRentalWebApplication.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalWebApplication.Configuration
{
    public static class DbContextConfig
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblyName = typeof(ApplicationDbContext).Namespace;
            var connectionString = configuration["SqlConnectionConfig:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlServer(
                    connectionString,
                    b =>
                        {
                            b.MigrationsAssembly(assemblyName);
                            b.CommandTimeout(300);
                        }));
        }
    }
}