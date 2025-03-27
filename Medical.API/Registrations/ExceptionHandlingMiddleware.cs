using Medical.Model.DTOs.Responses;
using Medical.Model.Options.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;




namespace Medical.API.Registrations
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly JwtOptions _jwtOptions;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IOptions<JwtOptions> securityOptions)
        {
            _next = next;
            _logger = logger;
            _jwtOptions = securityOptions.Value;
        }



        public async Task InvokeAsync(HttpContext httpContext)
        {
            string message = string.Empty;
            try
            {
                if ((httpContext.Request.Path.Value == "/login") || (httpContext.Request.Path.Value == "/refreshtoken")|| (httpContext.Request.Path.Value == "/OTPVerify"))
                {
                    await _next.Invoke(httpContext);
                    return;
                }
                else
                {
                    message = await GetVictoriaUserIdMessageAsync(httpContext);
                    _logger.LogInformation(message);
                    await _next(httpContext);



                }
            }
            catch (Exception ex)
            {
                _logger.LogError(message + "Error: " + ex.GetType().FullName);
                await HandleExceptionAsync(httpContext, ex);
            }
        }



        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;



            var errorResponse = new Model.DTOs.Responses.ErrorResponse
            {
                Success = false
            };
            switch (exception)
            {
                case ApplicationException ex:
                    if (ex.Message.Contains("Invalid Token"))
                    {
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorResponse.Message = ex.Message;
                        break;
                    }
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = ex.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error!";
                    break;
            }
            _logger.LogError(exception.Message);
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
        private async Task<string> GetVictoriaUserIdMessageAsync(HttpContext context)
        {
            var email = string.Empty;
            string authHeader = context.Request.Headers["Authorization"];
            string beareaHeader = authHeader.Substring(0, 6).Trim().ToLower();
            if (authHeader != null && beareaHeader.StartsWith("bearer"))
            {
                //Extract credentials
                JwtSecurityTokenHandler handler = new();
                string token = authHeader.Substring("bearer ".Length).Trim();
                handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                email = "UserId: " + jwtToken.Claims.First(x => x.Type == "email").Value + "; URL: " + context.Request.Path + "; ";



            }
            return email;
        }
        
    }
}