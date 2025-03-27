using Microsoft.Extensions.Logging;
using Refit;

namespace Medical.Common.Refit.Extensions.Logging
{
    /// <summary>
    /// The logging extensions class
    /// </summary>
    public static partial class LoggingExtensions
    {
        /// <summary>
        /// Logs the refit request failed using the specified logger
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="logger">The logger</param>
        /// <param name="response">The response</param>
        public static void LogRefitRequestFailed<T>(this ILogger<T> logger, IApiResponse response)
        {
            logger.LogError("[RefitRequestFail] {Uri} {StatusCode} {ReasonPhrase} {Content}",
                response.Error?.Uri,
                response.StatusCode,
                response.ReasonPhrase,
                response.Error?.Content);
        }
    }
}
