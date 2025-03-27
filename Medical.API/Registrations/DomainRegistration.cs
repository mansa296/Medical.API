using Microsoft.AspNetCore.Authorization;
using Medical.API.Middlewares;
using Medical.Domain.AuthDomain;
using Medical.Domain.RoleDomain;
using Medical.Domain.TokenDomain;
using Medical.Domain.UserDomain;
using Medical.Domain.UserRoleDomain;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the domains using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection RegisterDomains(this IServiceCollection services)
        {
            return services
                .AddScoped<IAuthDomain, AuthDomain>()
                //.AddScoped<IAuthorizationMiddlewareResultHandler, TokenAuthorizationMiddleware>()
                .AddScoped<ITokenDomain, TokenDomain>()
                .AddScoped<IUserDomain, UserDomain>()
                .AddScoped<IRoleDomain, RoleDomain>()
                .AddScoped<IUserRoleDomain, UserRoleDomain>();
        }
    }
}