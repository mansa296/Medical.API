using Medical.Common.Constants;
using Medical.Data.EF;
using Medical.Data.EF.Classes;
using Medical.Data.EF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The entity framework registration extensions class
    /// </summary>
    public static class EntityFrameworkRegistrationExtensions
    {
        /// <summary>
        /// Registers the entity framework using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The services</returns>
        public static IServiceCollection RegisterEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MedicalDbContext>(options =>
            {
                string conn = configuration[UtilityContants.DataAccessConnectionString];

                var dbConnection = new Microsoft.Data.SqlClient.SqlConnection(conn);

                options.UseSqlServer(dbConnection, providerOptions => providerOptions
                .EnableRetryOnFailure());
            });

            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));

            return services;
        }
    }
}
