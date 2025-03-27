using Medical.Service.Adapter;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the adapters using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The services</returns>
        public static IServiceCollection RegisterAdapters(this IServiceCollection services)
        {
            services.AddScoped<IEfRepositoryAdapter, EfRepositoryAdapter>();

            return services;
        }
    }
}