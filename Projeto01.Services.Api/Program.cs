using Projeto01.Services.Api.Configurations;
using Projeto01.Services.Api.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ApplicationConfig.AddApplicationConfig(builder);
DomainConfig.AddDomainConfig(builder);
RepositoryConfig.AddRepositoryConfig(builder);
CacheConfig.AddCacheConfig(builder);

builder.Services.AddControllers();

SwaggerSetup.AddSwaggerSetup(builder);
CorsSetup.AddCorsSetup(builder);
JwtSetup.AddJwtSetup(builder);  

var app = builder.Build();

SwaggerSetup.UseSwaggerSetup(app);
CorsSetup.UseCorsSetup(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }