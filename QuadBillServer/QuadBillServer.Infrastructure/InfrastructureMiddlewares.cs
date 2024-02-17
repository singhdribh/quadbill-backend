using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuadBillServer.SqlLite.Data;

namespace QuadBillServer.Infrastructure
{
    public static class InfrastructureMiddlewares
    {
        public static IApplicationBuilder UseInfraMiddleware(this IApplicationBuilder app)
        {
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var sqliteContext = serviceScope.ServiceProvider.GetRequiredService<IDbContextFactory<SqliteDataContext>>();
                using (var ctx = sqliteContext.CreateDbContext())
                {
                    ctx.MigrateDatabase().GetAwaiter().GetResult();
                }
            }
            return app;
        }
    }
}
