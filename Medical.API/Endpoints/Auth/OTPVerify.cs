using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Medical.Common;
using Medical.Domain.AuthDomain;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.Options.Security;

namespace Medical.API.Endpoints.Auth
{
    public class OTPVerify : EndpointBaseAsync
        .WithRequest<OPTVerifyRequest>
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The auth domain
        /// </summary>
        private readonly IAuthDomain _authDomain;
        private readonly JwtOptions _jwtOptions;
        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class
        /// </summary>
        /// <param name="authDomain">The auth domain</param>
        public OTPVerify(IAuthDomain authDomain, IOptions<JwtOptions> securityOptions)
        {
            _authDomain = authDomain;
            _jwtOptions = securityOptions.Value;
        }

        /// <summary>
        /// Handles the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpPost("OTPVerify"), AllowAnonymous]
        //[Authorize(AuthenticationSchemes = CTHAuthenticationSchemes.MicrosoftAuthScheme)]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<AuthenticateResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Tags = new[] { "Login" })]
        public override async Task<IActionResult> HandleAsync(OPTVerifyRequest request, CancellationToken cancellationToken = default)
        {
            JwtSecurityTokenHandler handler = new();
            handler.ValidateToken(request.Token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            var email = jwtToken.Claims.First(x => x.Type == "email");

            var response = await _authDomain.OTPVerifyAsync(email.Value,request.OTP);

            if (!response.Success)
            {
                if (response.Message == ErrorMessages.InactiveUserContactAdmin)
                {
                    return StatusCode(403, response);
                }
                else
                {
                    return StatusCode(403, response);
                }
            }

            return Ok(response);
        }
    }
}
