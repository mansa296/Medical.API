using Microsoft.Extensions.Logging;


namespace Medical.Infrastructure.Integration.Middlewares
{
    /// <summary>
    /// The refit integration logging middleware class
    /// </summary>
    /// <seealso cref="DelegatingHandler"/>
    public class RefitIntegrationLoggingMiddleware : DelegatingHandler
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<RefitIntegrationLoggingMiddleware> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="RefitIntegrationLoggingMiddleware"/> class
        /// </summary>
        /// <param name="logger">The logger</param>
        public RefitIntegrationLoggingMiddleware(ILogger<RefitIntegrationLoggingMiddleware> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Sends the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the http response message</returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Executing: {RequestUri}", request);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
