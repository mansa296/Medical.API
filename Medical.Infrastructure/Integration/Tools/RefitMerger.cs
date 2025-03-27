using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;

namespace Medical.Infrastructure.Integration.Tools
{
    /// <summary>
    /// The refit merger class
    /// </summary>
    public class RefitMerger
    {
        /// <summary>
        /// The services
        /// </summary>
        private readonly IServiceCollection _services;
        /// <summary>
        /// The http client builders
        /// </summary>
        private List<IHttpClientBuilder> _httpClientBuilders;
        /// <summary>
        /// The default settings
        /// </summary>
        private readonly RefitSettings _defaultSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="RefitMerger"/> class
        /// </summary>
        /// <param name="services">The services</param>
        private RefitMerger(IServiceCollection services)
        {
            _services = services;
            _httpClientBuilders = new List<IHttpClientBuilder>();
            _defaultSettings = new()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                })
            };
        }

        /// <summary>
        /// Creates the services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The refit merger</returns>
        public static RefitMerger Create(IServiceCollection services) => new(services);

        /// <summary>
        /// Adds the client using the specified settings
        /// </summary>
        /// <typeparam name="TApi">The api</typeparam>
        /// <param name="settings">The settings</param>
        /// <returns>The refit merger</returns>
        public RefitMerger AddClient<TApi>(RefitSettings? settings = null)
            where TApi : class
        {
            var client = _services.AddRefitClient<TApi>(settings ?? _defaultSettings);
            _httpClientBuilders.Add(client);    
            return this;
        }

        /// <summary>
        /// Attaches message handler to all previously added clients
        /// </summary>
        /// <typeparam name="THandler"></typeparam>
        /// <returns></returns>
        public RefitMerger AttachMessageHandler<THandler>()
            where THandler : DelegatingHandler
        {
            foreach (var handler in _httpClientBuilders)
            {
                handler.AddHttpMessageHandler<THandler>();
            }
            return this;
        }

        /// <summary>
        /// Configures all previously added clients
        /// </summary>
        /// <typeparam name="THandler"></typeparam>
        /// <returns></returns>
        public RefitMerger ConfigureHttpClient(Action<HttpClient> action)
        {
            foreach (var client in _httpClientBuilders)
            {
                client.ConfigureHttpClient(action);
            }

            return this;
        }

    }
}
