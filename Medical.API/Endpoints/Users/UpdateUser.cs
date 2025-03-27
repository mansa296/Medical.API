using Ardalis.ApiEndpoints;
using Medical.Domain.UserDomain;
using Medical.Model.DTOs.Requests.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Medical.API.Endpoints.Users
{
    /// <summary>
    /// The update user class
    /// </summary>
    public class UpdateUser : EndpointBaseAsync
        .WithRequest<UpdateUserRequest>
        .WithResult<IActionResult>
    {
        /// <summary>
        /// The user domain
        /// </summary>
        private readonly IUserDomain _userDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUser"/> class
        /// </summary>
        /// <param name="userDomain">The user domain</param>
        public UpdateUser(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        /// <summary>
        /// Handles the request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>A task containing the action result</returns>
        [HttpPut("user/update")]
        //[Authorize(Roles = "Admin,Orion Cloud Architect")]
        [SwaggerOperation(Tags = new[] { "User" })]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public override async Task<IActionResult> HandleAsync(UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            await _userDomain.UpdateAsync(request);
            return NoContent();
        }
    }
}
