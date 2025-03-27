using Medical.Model.Entities;

namespace Medical.Repository.RoleRepository
{
    /// <summary>
    /// The role repository interface
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Gets the by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing an enumerable of role</returns>
        Task<IEnumerable<Role>> GetByUserIdAsync(int userId);
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing an enumerable of role</returns>
        Task<IEnumerable<Role>> GetAllAsync();
        /// <summary>
        /// Gets the by user id using the specified user id
        /// </summary>
        /// <param name="userId">The user id</param>
        /// <returns>A task containing an enumerable of role</returns>
        Task<IEnumerable<Role>> GetByRoleIdAsync(int roleId);
    }
}