
using Medical.Service.CssConfig;
using Medical.Service.FileExtension;
using Medical.Service.MailService;
using Medical.Service.MenuService;
using Medical.Service.UpDownLoadFiles;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The service registration extensions class
    /// </summary>
    public static class ServiceRegistrationExtensions
    {
        /// <summary>
        /// Registers the services using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The services</returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ICssConfigService, CssConfigService>();
            services.AddScoped<IMenuService, MenuService>();

            return services;
        }
    }
}
