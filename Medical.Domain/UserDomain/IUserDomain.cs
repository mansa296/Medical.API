using Medical.Model.DTOs.Requests;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.DTOs.Responses.Users;
using Medical.Model.Entities;
using System.Security.Claims;

namespace Medical.Domain.UserDomain
{
    /// <summary>
    /// The user domain interface
    /// </summary>
    public interface IUserDomain
    {
        Task CreateAsync(CreateUserRequest createRequest);
        /// <summary>
        /// Gets the all using the specified paginated request
        /// </summary>
        /// <param name="paginatedRequest">The paginated request</param>
        /// <returns>A task containing a command response of i enumerable user with roles response</returns>
        Task<CommandResponse<IEnumerable<Users>>> GetAllAsync();
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        Task<CommandResponse<Users>> GetByIdAsync(int userId);
        /// <summary>
        /// Gets the by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing the user</returns>
        Task<Users?> GetByEmail(string email);
        /// <summary>
        /// Gets the by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        Task<CommandResponse<UserWithRolesResponse>> GetByEmailAsync(string email);
       /// <summary>
        /// Updates the update request
        /// </summary>
        /// <param name="updateRequest">The update request</param>
        Task UpdateAsync(UpdateUserRequest updateRequest);
        /// <summary>
        /// Updates the activity status using the specified activity status request
        /// </summary>
        /// <param name="activityStatusRequest">The activity status request</param>
        Task UpdateActivityStatusAsync(UpdateActivityStatusRequest activityStatusRequest);
        /// <summary>
        /// Updates the country using the specified country request
        /// </summary>
        /// <param name="countryRequest">The country request</param>
        Task UpdateCountryAsync(UpdateCountryRequest countryRequest);

        /// <summary>
        /// Gets the by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <param name="claimsPrincipal">The claimsPrincipal</param>
        /// <returns>A task containing a command response of user with roles response</returns>
        Task<CommandResponse<AuthenticateResponse>> GetUserDetailByEmailAsync(string email);


    }
}