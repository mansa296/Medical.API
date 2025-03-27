using Medical.Common;
using Microsoft.AspNetCore.Diagnostics;

namespace Medical.API.Registrations
{
    /// <summary>
    /// The registration extensions class
    /// </summary>
    public static partial class RegistrationExtensions
    {
        /// <summary>
        /// Registers the middlewares using the specified web application
        /// </summary>
        /// <param name="webApplication">The web application</param>
        public static void RegisterMiddlewares(this WebApplication webApplication)
        {
            webApplication.UseExceptionHandler(appError => {
                appError.Run(async (context) => {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        await context.Response.WriteAsync(ErrorMessages.SomethingWentWrong);
                    }
                });
            });
        }
    }
}
