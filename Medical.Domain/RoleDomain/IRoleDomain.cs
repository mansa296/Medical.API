using Medical.Model.DTOs.Responses;
using Medical.Model.DTOs.Responses.Roles;

namespace Medical.Domain.RoleDomain
{
    /// <summary>
    /// The role domain interface
    /// </summary>
    public interface IRoleDomain
    {
        /// <summary>
        /// Gets the all
        /// </summary>
        /// <returns>A task containing a command response of i enumerable role response</returns>
        Task<CommandResponse<IEnumerable<RoleResponse>>> GetAllAsync();
    }
}
