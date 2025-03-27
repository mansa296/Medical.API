using Medical.Model.Entities;

namespace Medical.Repository.UserRoleRepository
{
    /// <summary>
    /// The user role repository interface
    /// </summary>
    public interface IUserRoleRepository
    {
        /// <summary>
        /// Creates the user role
        /// </summary>
        /// <param name="userRole">The user role</param>
        Task CreateAsync(UserRole userRole);
        /// <summary>
        /// Deletes the roles for user using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        Task DeleteRolesForUserAsync(int userId);
        /// <summary>
        /// Gets the by id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing the user</returns>
        Task<Role> GetRoleByUserAsync(int userId);
    }
}