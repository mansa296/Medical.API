using Ardalis.ApiEndpoints;
using Medical.Domain.UserDomain;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.API.Endpoints.Users
{
    /// <summary>
    /// The get user by id class
    /// </summary>
    public class GetUserById : EndpointBaseAsync
        .WithRequest<int>
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The user domain
        /// </summary>
        private readonly IUserDomain _userDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserById"/> class
        /// </summary>
        /// <param name="userDomain">The user domain</param>
        public GetUserById(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        /// <summary>
        /// Handles the user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpGet("user/{userId}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Tags = new[] { "User" })]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<IEnumerable<UserWithRolesResponse>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> HandleAsync([FromRoute] int userId, CancellationToken cancellationToken = default)
        {
            var response = await _userDomain.GetByIdAsync(userId);

            if (response.Result is null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
