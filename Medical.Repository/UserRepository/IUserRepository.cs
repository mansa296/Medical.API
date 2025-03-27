using Medical.Model.DTOs.Requests;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.Entities;

namespace Medical.Repository.UserRepository
{
    /// <summary>
    /// The user repository interface
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing the user</returns>
        Task<Users?> GetUserByEmailAsync(string email);
        /// <summary>
        /// Gets the all using the specified paginated request
        /// </summary>
        /// <param name="paginatedRequest">The paginated request</param>
        /// <returns>A task containing an enumerable of user</returns>
        Task<IEnumerable<Users>> GetAllAsync();
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        Task<Users> GetByUserIdAsync(int userId);
        /// <summary>
        /// Creates the user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A task containing the int</returns>
        Task<int> CreateAsync(Users user);
        /// <summary>
        /// Updates the user
        /// </summary>
        /// <param name="user">The user</param>
        Task UpdateAsync(Users user);
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
        /// Gets the user by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing the user</returns>
        Task<Users?> GetUserByEmailBUAsync(string email, Guid UserBUId);
        /// <summary>
        /// Gets the user by email using the specified email
        /// </summary>
        /// <param name="email">The email</param>
        /// <returns>A task containing the user</returns>
        Task<UserLogin?> GetUserByEmailPasswordAsync(string email, string password);
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        Task<Users> GetByIdAsync(string id);
    }
}