using Pojeto01.Application.Services;
using Projeto01.Domain.Interfaces;
using Projeto01.Domain.Services;

namespace Projeto01.Services.Api.Configurations
{
   public static class DomainConfig
   {
        public static void AddDomainConfig(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IContatoDomainService, ContatoDomainService>();
   
        }
   }
}
