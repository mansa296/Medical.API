using Medical.Common.Enums;
using Medical.Common.Helpers;
using Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.Model;
using Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.TokenFetcher;
using Medical.Model.Options.Integrations;
using System.Reflection.PortableExecutable;

namespace Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider
{
    /// <summary>
    /// The integration token provider class
    /// </summary>
    /// <seealso cref="IIntegrationTokenProvider"/>
    public class IntegrationTokenProvider : IIntegrationTokenProvider
    {
        /// <summary>
        /// The token validity minute offset
        /// </summary>
        private readonly int _tokenValidityMinuteOffset = 2;
        /// <summary>
        /// The token fetch max retry
        /// </summary>
        private readonly int _tokenFetchMaxRetry = 3;

        /// <summary>
        /// The token fetchers
        /// </summary>
        private readonly IEnumerable<ITokenFetcher> _tokenFetchers;
        /// <summary>
        /// The entries
        /// </summary>
        private readonly List<IntegrationTokenProviderEntry> _entries;
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTokenProvider"/> class
        /// </summary>
        /// <param name="tokenFetchers">The token fetchers</param>
        public IntegrationTokenProvider(IEnumerable<ITokenFetcher> tokenFetchers)
        {
            _tokenFetchers = tokenFetchers;
            _entries = new List<IntegrationTokenProviderEntry>();
        }

        /// <summary>
        /// Gets the token using the specified subsystem
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        /// <returns>A task containing the string</returns>
        public async Task<string?> GetTokenAsync(IntegrationSubsystem subsystem)
        {
            var entry = GetValidEntry(subsystem);

            //if (entry is not null)
            //{
            //    return entry.FetchedToken.Token;
            //}

            ClearEntriesForSubsystem(subsystem);

            var fetchedToken = await FetchTokenAsync(subsystem);

            if (fetchedToken is not null)
            {
                _entries.Add(new(subsystem, fetchedToken.Value));
            }

            return fetchedToken?.Token;
        }

        /// <summary>
        /// Fetches the token using the specified subsystem
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        /// <param name="retryNo">The retry no</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>A task containing the fetched token</returns>
        private async Task<FetchedToken?> FetchTokenAsync(IntegrationSubsystem subsystem, int retryNo = 1)
        {
            var tokenFetcher = _tokenFetchers
                .Where(t => t.Subsystem == subsystem)
                .FirstOrDefault();

            if (tokenFetcher is null)
            {
                var message = $"{nameof(ITokenFetcher)} not implemented for {nameof(IntegrationSubsystem)} of type {EnumHelper.GetDescription(subsystem)}";
                throw new NotImplementedException(message);
            }


            //if (retryNo <= _tokenFetchMaxRetry)
            //{
            //    retryNo++;
            //    var fetchedToken = await tokenFetcher.FetchAsync();
            //    return fetchedToken ?? await FetchTokenAsync(subsystem, retryNo);
            //}

            //return null;

            var fetchedToken = await tokenFetcher.FetchAsync();
            return fetchedToken ?? await FetchTokenAsync(subsystem, retryNo);
        }
        /// <summary>
        /// Gets the valid entry using the specified subsystem
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        /// <returns>The integration token provider entry</returns>
        private IntegrationTokenProviderEntry? GetValidEntry(IntegrationSubsystem subsystem)
        {
            return _entries
                .Where(e => e.Subsystem == subsystem && e.FetchedToken.ValidTo >= DateTime.Now.AddMinutes(_tokenValidityMinuteOffset))
                .FirstOrDefault();
        }

        /// <summary>
        /// Clears the entries for subsystem using the specified subsystem
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        private void ClearEntriesForSubsystem(IntegrationSubsystem subsystem)
        {
            var target = _entries
                .Where(e => e.Subsystem == subsystem)
                .FirstOrDefault();

            if (target is not null)
            {
                _entries.Remove(target);
            }
        }
        public async Task<string?> FetchTxtureToken(IntegrationSubsystem subsystem)
        {
            var tokenFetcher = _tokenFetchers
                .Where(t => t.Subsystem == subsystem)
                .FirstOrDefault();

            var fetchedToken = await tokenFetcher.FetchTxtureTokenAsync();
            return fetchedToken?.Token;
        }
    }
}
