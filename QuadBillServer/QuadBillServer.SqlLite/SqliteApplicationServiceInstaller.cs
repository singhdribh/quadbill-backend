using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace QuadBillServer.SqlLite
{
    public static class SqliteApplicationServiceInstaller
    {
        public static IServiceCollection AddSqliteApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
