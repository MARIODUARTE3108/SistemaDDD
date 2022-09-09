using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Interfaces;
using Projeto01.Infra.Data.SqlServer.Contexts;
using Projeto01.Infra.Data.SqlServer.Repositories;

namespace Projeto01.Services.Api.Configurations
{
    public static class RepositoryConfig
    {
        public static void AddRepositoryConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

            var connectionString = builder.Configuration.GetConnectionString("BDProjeto01");
            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
