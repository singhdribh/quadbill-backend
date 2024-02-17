using QuadBillServer;
using QuadBillServer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();

services.AddHttpContextAccessor();


services.AddGraphQLServer().AddGraphqlService(services, configuration);
var app = builder.Build();
app.UseInfraMiddleware();
//app.UseAuthentication();
//app.UseAuthorization();
app.MapGraphQL();
app.MapDefaultControllerRoute();

app.Run();
