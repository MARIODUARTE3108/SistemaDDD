using MediatR;
using Pojeto01.Application.Interfaces;
using Pojeto01.Application.Services;

namespace Projeto01.Services.Api.Configurations
{
    public static class ApplicationConfig
    {
        public static void AddApplicationConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IContatoAppService, ContatoAppService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
