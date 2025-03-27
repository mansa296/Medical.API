using Medical.API.Constants;
using Medical.Model.Options.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Diagnostics;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the auth using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The services</returns>
        public static IServiceCollection RegisterAuth(this IServiceCollection services, IConfiguration configuration)
        {
            JwtOptions jwtOptions = new();
            //MicrosoftAuthOptions microsoftAuthOptions = new();
            //AzureAdN azureAdN = new();

            configuration.GetSection("Security:JWTConfig").Bind(jwtOptions);
            Trace.TraceInformation($"'{configuration.GetSection("Security:JWTConfig")}'...'{configuration.GetSection("AzureAdN")}'...'{configuration.GetSection("MailSettings")}'");
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(configuration,"AzureAdN");
            
            return services;
        }
    }


}
