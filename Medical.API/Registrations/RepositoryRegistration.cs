using Medical.Repository.CssConfigRespository;
using Medical.Repository.MenuRepository;
using Medical.Repository.RoleRepository;
using Medical.Repository.TokenRepository;
using Medical.Repository.UserRepository;
using Medical.Repository.UserRoleRepository;


namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the repositories using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ITokenRepository, TokenRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IUserRoleRepository, UserRoleRepository>()
                .AddScoped<ICssConfigRespository, CssConfigRespository>()
                .AddScoped<IMenuRepository, MenuRepository>();
                //.AddScoped<EmailCommunicationFiltercs>();
        }
    }
}
