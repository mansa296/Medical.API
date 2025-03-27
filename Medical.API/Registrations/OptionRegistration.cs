using Medical.Common.Constants;
using Medical.Model.Options;
using Medical.Model.Options.Mail;
using Medical.Model.Options.Security;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;
using System.Diagnostics;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the options using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The services</returns>
        public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            Trace.TraceInformation($"'{configuration.GetSection("Security:JWTConfig")}'...'{configuration.GetSection("AzureAdN")}'...'{configuration.GetSection("MailSettings")}'");
            services
            .Configure<DataAccessOptions>(configuration.GetSection(UtilityContants.DataAccess))
            .Configure<JwtOptions>(configuration.GetSection("Security:JWTConfig"))
            //.Configure<MicrosoftAuthOptions>(configuration.GetSection("Security:JWTConfig:MicrosoftAuth"))
                .Configure<AzureAdN>(configuration.GetSection("AzureAdN"))
                .Configure<MailSettings>(configuration.GetSection("MailSettings"));
                //.Configure<AzureStorage>(configuration.GetSection("AzureStorage"));

            return services;
        }

        /// <summary>
        /// Registers the integration options using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The service collection</returns>
        private static IServiceCollection RegisterIntegrationOptions(this IServiceCollection services, IConfiguration configuration)
        {
            var subsystemSection = configuration.GetSection("Integration:Subsystems");

            return services;

        }
    }
}
