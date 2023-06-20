using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kyrldama.Backoffice.DataAccess.OdataClient.Orchestrator;
using Microsoft.Extensions.Options;
using Kyrldama.Backoffice.Infrastructure;
using Kyrldama.Backoffice.Business.Interface;
using Kyrldama.Backoffice.Business;

namespace Kyrldama.Backoffice.Host
{
    public static class DependencyConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration = null)
        {
            ConfigureOrchestrator(services, configuration);
            ConfigureEntity(services, configuration);
        }

        private static void ConfigureOrchestrator(IServiceCollection services, IConfiguration configuration = null)
        {
            services.Configure<HttpClientConfiguration>(c =>
            {
                configuration.GetSection("Services:Orchestrator").Bind(c);
            });

            services.AddHttpClient<OrchestratorClient>((provider, httpClient) =>
            {
                var httpClientConfiguration = provider.GetRequiredService<IOptions<HttpClientConfiguration>>();
                httpClient.BaseAddress = new Uri(httpClientConfiguration.Value.Url);
            });
        }

        private static void ConfigureEntity(IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddScoped<IEntityManager, EntityManager>();
        }

    }
}
