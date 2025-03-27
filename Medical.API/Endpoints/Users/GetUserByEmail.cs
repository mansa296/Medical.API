using Ardalis.ApiEndpoints;
using Medical.Domain.UserDomain;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.DTOs.Responses.Users;
using Medical.Model.Options.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Medical.API.Endpoints.Users
{
    /// <summary>
    /// The get user by email class
    /// </summary>
    public class GetUserByEmail : EndpointBaseAsync
       .WithoutRequest
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The user domain
        /// </summary>
        private readonly IUserDomain _userDomain;
        private readonly JwtOptions _jwtOptions;
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmail"/> class
        /// </summary>
        /// <param name="userDomain">The user domain</param>
        public GetUserByEmail(IUserDomain userDomain, IOptions<JwtOptions> securityOptions)
        {
            _userDomain = userDomain;
            _jwtOptions = securityOptions.Value;
        }

        /// <summary>
        /// Handles the email
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpGet("user/userdetail")]
        //[Authorize(Roles = "Admin")]
        [SwaggerOperation(Tags = new[] { "User" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<AuthenticateResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {

            string authHeader = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                return NoContent();
            }
            string beareaHeader = authHeader.Substring(0, 6).Trim().ToLower();

            if (authHeader != null && beareaHeader.StartsWith("bearer"))
            {

                //Extract credentials
                JwtSecurityTokenHandler handler = new();
                string token = authHeader.Substring("bearer ".Length).Trim();

                try
                {
                    handler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = (JwtSecurityToken)validatedToken;

                    string tokenemail = jwtToken.Claims.First(x => x.Type == "email").Value;
                    
                        
                            var response = await _userDomain.GetUserDetailByEmailAsync(tokenemail);

                            if (response.Result is null)
                            {
                                return NotFound();
                            }

                            return Ok(response);

                       
                    
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                    // throw;
                }
            }
            return Unauthorized();

            

        }

    }
}
