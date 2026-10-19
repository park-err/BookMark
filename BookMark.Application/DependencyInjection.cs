using BookMark.Application.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace BookMark.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Registers application services into the DI container.
        /// </summary>
        public static IServiceCollection AddBookMarkApplication(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // session context
            // services.AddScoped<ISessionContext, SessionContext>();

            // Register HttpClient for CatalogService
            services.AddHttpClient<Interfaces.ICatalogService, Services.CatalogService>((provider, client) =>
            {
                // configured options from host
                var options = provider.GetService<IOptions<GoogleBooksOptions>>()?.Value;
                if (!string.IsNullOrWhiteSpace(options?.BaseAddress))
                {
                    client.BaseAddress = new Uri(options.BaseAddress);
                }
                client.Timeout = TimeSpan.FromSeconds(10);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            return services;
        }
    }
}
