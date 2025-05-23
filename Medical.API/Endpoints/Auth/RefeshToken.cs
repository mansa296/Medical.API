﻿using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Medical.Common;
using Medical.Domain.AuthDomain;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
namespace Medical.API.Endpoints.Auth
{
    public class RefeshToken : EndpointBaseAsync
        .WithRequest<AuthenticateResponse>
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
        public RefeshToken(IAuthDomain authDomain)
        {
            _authDomain = authDomain;
        }

        /// <summary>
        /// Handles the cancellation token
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpPost("refreshtoken"), AllowAnonymous]
        //[Authorize(AuthenticationSchemes = CTHAuthenticationSchemes.MicrosoftAuthScheme)]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<AuthenticateResponse>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation(Tags = new[] { "Login" })]
        public override async Task<IActionResult> HandleAsync(AuthenticateResponse request, CancellationToken cancellationToken = default)
        {
            var response = await _authDomain.RefreshTokenAsync(request);

            if (!response.Success)
            {
                if (response.Message == ErrorMessages.InactiveUserContactAdmin)
                {
                    return StatusCode(403, response);
                }
                else
                {
                    return Unauthorized(response);
                }
            }

            return Ok(response);
        }
    }
}
