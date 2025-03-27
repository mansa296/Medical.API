using Medical.Model.Options.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Medical.Infrastructure.Security.TokenProvider
{
    /// <summary>
    /// The token provider class
    /// </summary>
    /// <seealso cref="ITokenProvider"/>
    public class TokenProvider : ITokenProvider
    {
        /// <summary>
        /// The jwt options
        /// </summary>
        private readonly JwtOptions _jwtOptions;
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProvider"/> class
        /// </summary>
        /// <param name="securityOptions">The security options</param>
        public TokenProvider(IOptions<JwtOptions> securityOptions)
        {
            _jwtOptions = securityOptions.Value;
        }

        /// <summary>
        /// Generates the token using the specified claims
        /// </summary>
        /// <param name="claims">The claims</param>
        /// <param name="tokenDate">The claims</param>
        /// <returns>The string</returns>
        public string GenerateToken(Claim[] claims)
        {
            JwtSecurityTokenHandler handler = new();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            SecurityTokenDescriptor descriptor = new()
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Subject = new(claims),
                Expires = DateTime.Now.AddMinutes(_jwtOptions.ExpireInMinutes),
                SigningCredentials = new(key, SecurityAlgorithms.Aes128CbcHmacSha256)
                //SigningCredentials = new(key, SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
        public string OtpGenerateToken(Claim[] claims)
        {
            JwtSecurityTokenHandler handler = new();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
            SecurityTokenDescriptor descriptor = new()
            {
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Subject = new(claims),
                Expires = DateTime.Now.AddMinutes(_jwtOptions.ExpireInMinutes),
                SigningCredentials = new(key, SecurityAlgorithms.Aes128CbcHmacSha256)
                //SigningCredentials = new(key, SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
        /// <summary>
        /// Describes whether this instance try generate token
        /// </summary>
        /// <param name="claims">The claims</param>
        /// <param name="token">The token</param>
        /// <returns>The bool</returns>
        public bool TryGenerateToken(Claim[] claims, out string? token)
        {
            try
            {
                var tokenDate = DateTimeOffset.FromUnixTimeSeconds(0).UtcDateTime;
                token = GenerateToken(claims);
                return true;
            }
            catch
            {
                token = null;
                return false;
            }
        }
    }
}
