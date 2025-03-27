using AutoMapper;
using Medical.Model.DTOs.Requests.UserRoles;
using Medical.Model.Entities;

namespace Medical.Domain.UserRoleDomain
{
    /// <summary>
    /// The user role mappings class
    /// </summary>
    /// <seealso cref="Profile"/>
    public class UserRoleMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRoleMappings"/> class
        /// </summary>
        public UserRoleMappings()
        {
            CreateMap<UpdateUserRoleRequest, UserRole>().IncludeAllDerived();
        }
    }
}
