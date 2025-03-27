using Medical.Common.Enums;
using Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.Model;

namespace Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.TokenFetcher
{
    /// <summary>
    /// The token fetcher interface
    /// </summary>
    public interface ITokenFetcher
    {
        /// <summary>
        /// Gets the value of the subsystem
        /// </summary>
        IntegrationSubsystem Subsystem { get; }
        /// <summary>
        /// Fetches this instance
        /// </summary>
        /// <returns>A task containing the fetched token</returns>
        Task<FetchedToken?> FetchAsync();
        /// <summary>
        /// Fetches this instance
        /// </summary>
        /// <returns>A task containing the fetched token</returns>
        Task<FetchedToken?> FetchTxtureTokenAsync();
    }
}
