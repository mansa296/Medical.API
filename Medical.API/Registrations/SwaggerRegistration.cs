using Microsoft.OpenApi.Models;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the swagger using the specified services
        /// </summary>
        /// <param name="services">The services</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            return services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new() { Title = "Medical API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new()
                    {
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey
                    });

                   

                    c.AddSecurityRequirement(new()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
                    
                    
                    c.EnableAnnotations();
                });


        }

        /// <summary>
        /// Uses the registered swagger using the specified web application
        /// </summary>
        /// <param name="webApplication">The web application</param>
        /// <returns>The web application</returns>
        public static IApplicationBuilder UseRegisteredSwagger(this WebApplication webApplication)
        {
           // if (webApplication.Environment.IsDevelopment())
           // {
                webApplication
                    .UseSwagger()
                    .UseSwaggerUI();
               // }

            return webApplication;
        }
    }
}
