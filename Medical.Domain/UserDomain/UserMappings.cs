using AutoMapper;
using Medical.Infrastructure.Security;
using Medical.Model.DTOs.Requests.Users;
using Medical.Model.DTOs.Responses.Users;
using Medical.Model.Entities;

namespace Medical.Domain.UserDomain
{
    /// <summary>
    /// The user mappings class
    /// </summary>
    /// <seealso cref="Profile"/>
    public class UserMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMappings"/> class
        /// </summary>
        public UserMappings()
        {
            CreateMap<Users, UserResponseBase>()
                .IncludeAllDerived();

            CreateMap<UpdateUserRequest, Users>()
                .IncludeAllDerived();
        }
    }
}