using HotChocolate.Execution.Configuration;
using Microsoft.EntityFrameworkCore;
using QuadBillServer.GraphQL.Admin;
using QuadBillServer.GraphQL.Base;
using QuadBillServer.Helpers.Interceptors;
using QuadBillServer.SqlLite.Data;
using System.Reflection;

namespace QuadBillServer
{
    public static class GraphqlInstaller
    {
        public static IRequestExecutorBuilder AddGraphqlService(this IRequestExecutorBuilder graphqlBuilder, IServiceCollection services, IConfiguration configurations)
        {
            var sqliteConnection = configurations.GetConnectionString("sqliteConnection");
            services.AddPooledDbContextFactory<SqliteDataContext>(option => option.UseSqlite(sqliteConnection).EnableServiceProviderCaching(false), poolSize: 32);

            graphqlBuilder
                .RegisterDbContext<SqliteDataContext>(DbContextKind.Pooled)
                .AddQueryType(p => p.Name("Query"));
            //.AddMutationType(p => p.Name("Mutation"))
            //.AddSubscriptionType(p => p.Name("Subscription"))
            //.AddInMemorySubscriptions();
            //.AddRavenFiltering()
            //.AddRavenProjections()
            //.AddRavenSorting()
            //.AddAuthorization()
            //.AddRavenPagingProviders()
            //.AddType<UploadType>()
            //.AddFluentValidation(o => o.UseDefaultErrorMapper())
            //.AddHttpRequestInterceptor<HeaderRequestInterceptor>();


            Assembly.GetExecutingAssembly().GetTypes()
                  .Where(x => (x.IsAssignableTo(typeof(QueryBase))
                  || x.IsAssignableTo(typeof(MutationBase))
                  || x.IsAssignableTo(typeof(SubscriptionBase))) && !x.IsAbstract).ToList().ForEach(x =>
                  {
                      graphqlBuilder.AddType(x);
                  });


            return graphqlBuilder;
        }
    }
}
