using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SureSuccessApp.Infrastructure;

namespace SureSuccessApp.DeleteService.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, string connectionString)
        {
            return services
                .AddEntityFrameworkSqlServer()
                .AddDbContext<AppDbContext>(opt =>
                {
                    opt.UseSqlServer(
                        connectionString,
                        x =>
                        {
                            //x.MigrationsAssembly(typeof(Startup)
                            //    .GetTypeInfo()
                            //    .Assembly
                            //    .GetName().Name);

                            x.MigrationsAssembly("SureSuccessApp.Infrastructure");
                        });
                });
        }
    }
}