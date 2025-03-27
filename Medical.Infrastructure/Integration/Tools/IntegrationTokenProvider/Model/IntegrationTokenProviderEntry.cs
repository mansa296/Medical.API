using Medical.Common.Enums;

namespace Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.Model
{
    /// <summary>
    /// The integration token provider entry class
    /// </summary>
    public class IntegrationTokenProviderEntry
    {
        /// <summary>
        /// Gets the value of the subsystem
        /// </summary>
        public IntegrationSubsystem Subsystem { get; }
        /// <summary>
        /// Gets the value of the fetched token
        /// </summary>
        public FetchedToken FetchedToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTokenProviderEntry"/> class
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        /// <param name="fetchedToken">The fetched token</param>
        public IntegrationTokenProviderEntry(IntegrationSubsystem subsystem, FetchedToken fetchedToken)
        {
            Subsystem = subsystem;
            FetchedToken = fetchedToken;
        }
    }
}
