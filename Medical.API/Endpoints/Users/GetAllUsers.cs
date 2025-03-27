using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Medical.Common;
using Medical.Domain.UserDomain;
using Medical.Model.DTOs.Responses;
using Medical.Model.Options.Security;
using Medical.Repository.RoleRepository;
using Medical.Repository.UserRepository;

namespace Medical.API.Endpoints.Users
{
    /// <summary>
    /// The get all users class
    /// </summary>
    public class GetAllUsers : EndpointBaseAsync
        .WithoutRequest
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The user domain
        /// </summary>
        private readonly IUserDomain _userDomain;
        private readonly JwtOptions _jwtOptions;
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// The role repository
        /// </summary>
        private readonly IRoleRepository _roleRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllUsers"/> class
        /// </summary>
        /// <param name="userDomain">The user domain</param>
        public GetAllUsers(IUserDomain userDomain, IOptions<JwtOptions> securityOptions,
                    IRoleRepository roleRepository,
                    IUserRepository userRepository)
        {
            _userDomain = userDomain;
            _jwtOptions = securityOptions.Value;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpGet("user")]
        //[Authorize(Roles = "Admin")]
        [SwaggerOperation(Tags = new[] { "User" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<IEnumerable<Medical.Model.Entities.Users>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> HandleAsync(
            CancellationToken cancellationToken = default)
        {
            var errorResponse = new Model.DTOs.Responses.ErrorResponse
            {
                Success = false
            };

            string authHeader = HttpContext.Request.Headers["Authorization"];

            if (string.IsNullOrEmpty(authHeader))
            {
                return Unauthorized();
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

                    var email = jwtToken.Claims.First(x => x.Type == "email");

                    if (email != null)
                    {
                        var user = await _userRepository.GetUserByEmailAsync(email.Value);
                        if (user is not null)
                        {
                            
                            return Ok(await _userDomain.GetAllAsync());
                            
                        }
                        else
                        {
                            errorResponse.Message = ErrorMessages.NotAuthorizedContactAdmin;
                            return StatusCode(400, errorResponse);
                        }
                    }
                    else
                    {
                        errorResponse.Message = ErrorMessages.NotAuthorizedContactAdmin;
                        return StatusCode(400, errorResponse);
                    }
                    
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Unauthorized();
            }
            return NoContent();
        }
    }
}
