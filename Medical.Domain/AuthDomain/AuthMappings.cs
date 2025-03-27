using AutoMapper;
using Medical.Model.DTOs.Responses.Auth;
using Medical.Model.Entities;

namespace Medical.Domain.AuthDomain
{
    /// <summary>
    /// The auth mappings class
    /// </summary>
    /// <seealso cref="Profile"/>
    public class AuthMappings : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthMappings"/> class
        /// </summary>
        public AuthMappings()
        {
           
            CreateMap<AuthenticateResponse, Token>()
                .ForMember(t => t.Value, src => src.MapFrom(l => l.Token));
        }
    }
}
