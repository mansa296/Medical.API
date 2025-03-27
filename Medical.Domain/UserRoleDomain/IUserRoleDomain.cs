using Medical.Model.DTOs.Requests.UserRoles;

namespace Medical.Domain.UserRoleDomain
{
    /// <summary>
    /// The user role domain interface
    /// </summary>
    public interface IUserRoleDomain
    {
        /// <summary>
        /// Updates the create request
        /// </summary>
        /// <param name="createRequest">The create request</param>
        Task UpdateAsync(UpdateUserRoleRequest createRequest);
    }
}
