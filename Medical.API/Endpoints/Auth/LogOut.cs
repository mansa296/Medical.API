using Ardalis.ApiEndpoints;
using Medical.Domain.AuthDomain;
using Medical.Model.DTOs.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.API.Endpoints.Auth
{
    /// <summary>
    /// The login class
    /// </summary>
    public class LogOut : EndpointBaseAsync
        .WithoutRequest
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The auth domain
        /// </summary>
        private readonly IAuthDomain _authDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class
        /// </summary>
        /// <param name="authDomain">The auth domain</param>
        public LogOut(IAuthDomain authDomain)
        {
            _authDomain = authDomain;
        }

        /// <summary>
        /// Handles the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Tags = new[] { "Auth" })]
        public override async Task<IActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            var response = await _authDomain.LogOut(HttpContext.Request.Headers.Authorization);

            if (!response.Success)
            {
                return Unauthorized(response);
            }

            return Ok(response);
        }
    }
}
