using AutoMapper;
using Medical.Model.DTOs.Responses.Users;
using Medical.Model.Entities;

namespace Medical.Service.Automapper
{
    /// <summary>
    /// The auto mapper service profile class
    /// </summary>
    /// <seealso cref="Profile"/>
    public class AutoMapperServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperServiceProfile"/> class
        /// </summary>
        public AutoMapperServiceProfile()
        {
            CreateMap<Users, UserBusinessUnitResponse>()
                 .ForMember(l => l.FullName, src => src.MapFrom(u => string.Concat(u.UserName)));

           
           
        }
    }
}