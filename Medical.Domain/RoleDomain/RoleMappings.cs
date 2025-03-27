using AutoMapper;
using Medical.Model.DTOs.Responses.Roles;
using Medical.Model.Entities;

namespace Medical.Domain.RoleDomain
{
    /// <summary>
    /// The role mappings class
    /// </summary>
    /// <seealso cref="Profile"/>
    public class RoleMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleMappings"/> class
        /// </summary>
        public RoleMappings()
        {
            CreateMap<Role, RoleResponse>()
                .IncludeAllDerived();
        }
    }
}
