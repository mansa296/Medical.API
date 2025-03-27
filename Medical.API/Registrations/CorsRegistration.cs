namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the cors using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <param name="configuration">The configuration</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection RegisterCors(this IServiceCollection services, IConfiguration configuration)
        {
            var configValue = configuration.GetSection("Security:AllowedOrigins").Get<string>();
            var origins = configValue?.Split(",")  ?? Array.Empty<string>();

            return services
                .AddCors(opts => {
                    opts.AddDefaultPolicy(builder => {
                        builder
                        .WithOrigins(origins)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
                });
        }

    }
}
