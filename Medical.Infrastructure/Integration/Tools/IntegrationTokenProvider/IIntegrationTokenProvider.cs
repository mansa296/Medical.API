using Medical.Common.Enums;

namespace Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider
{
    /// <summary>
    /// The integration token provider interface
    /// </summary>
    public interface IIntegrationTokenProvider
    {
        /// <summary>
        /// Gets the token using the specified subsystem
        /// </summary>
        /// <param name="subsystem">The subsystem</param>
        /// <returns>A task containing the string</returns>
        Task<string?> GetTokenAsync(IntegrationSubsystem subsystem);
        Task<string?> FetchTxtureToken(IntegrationSubsystem subsystem);
        
    }
}
