using FluentValidation.AspNetCore;
using Medical.Infrastructure.Integration.Middlewares;
using Medical.Infrastructure.Integration.Tools;
using Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider;
using Medical.Infrastructure.Persistence.DbConnectionProvider;
using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Infrastructure.Security.TokenProvider;

namespace Medical.API.Registrations
{
    //ToDo: Move integration registration to it's
    //folder inside Medical.Infrastructure
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the infrastructure using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var relatedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            return services
                .AddSingleton<ITokenProvider, TokenProvider>()
                .AddSingleton<IDbConnectionProvider, DbConnectionProvider>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddFluentValidation(_ => _.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()))
                .AddAutoMapper(relatedAssemblies);
        }
    }
}
