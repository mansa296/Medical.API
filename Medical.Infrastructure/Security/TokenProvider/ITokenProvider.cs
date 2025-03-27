using System.Security.Claims;

namespace Medical.Infrastructure.Security.TokenProvider
{
    /// <summary>
    /// The token provider interface
    /// </summary>
    public interface ITokenProvider
    {
        /// <summary>
        /// Generates the token using the specified claims
        /// </summary>
        /// <param name="claims">The claims</param>
        /// <param name="tokenDate">The claims</param>
        /// <returns>The string</returns>
        string GenerateToken(Claim[] claims);
        string OtpGenerateToken(Claim[] claims);
        /// <summary>
        /// Describes whether this instance try generate token
        /// </summary>
        /// <param name="claims">The claims</param>
        /// <param name="token">The token</param>
        /// <returns>The bool</returns>
        bool TryGenerateToken(Claim[] claims, out string? token);
    }
}