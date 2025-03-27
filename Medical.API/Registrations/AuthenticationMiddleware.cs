using Medical.Common;
using Medical.Common.Constants;
using Medical.Data.EF;
using Medical.Data.EF.Domain;
using Medical.Model.DTOs.Responses;
using Medical.Model.Options.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Medical.API.Extensions;
using Microsoft.Extensions.Logging;

namespace Medical.API.Registrations
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDistributedCache _cache;
        /// <summary>
        /// The jwt options
        /// </summary>
        private readonly JwtOptions _jwtOptions;
        private readonly ILogger<AuthenticationMiddleware> _logger;
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenProvider"/> class
        /// </summary>
        /// <param name="securityOptions">The security options</param>
        public AuthenticationMiddleware(RequestDelegate next, IOptions<JwtOptions> securityOptions, ILogger<AuthenticationMiddleware> logger, IDistributedCache cache)
        {
            _next = next;
            _jwtOptions = securityOptions.Value;
            _logger = logger;
            _cache = cache;
        }
        public async Task Invoke(HttpContext context, MedicalDbContext dbContext)
        {
            if ((context.Request.Path.Value == "/login")
               || (context.Request.Path.Value == "/refreshtoken")|| (context.Request.Path.Value == "/OTPVerify"))
            {
                await _next.Invoke(context);
                return;
            }

            string authHeader = context.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Unauthorized
                await Errorhandle(context);
                return;
            }
            string beareaHeader = authHeader.Substring(0, 6).Trim().ToLower();

            if (authHeader != null && beareaHeader.StartsWith("bearer"))
            {
                //Extract credentials
                JwtSecurityTokenHandler handler = new();
                string token = authHeader.Substring("bearer ".Length).Trim();


                try
                {
                    handler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);


                    var jwtToken = (JwtSecurityToken)validatedToken;

                    var email = jwtToken.Claims.First(x => x.Type == "email");
                    if (email == null)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Unauthorized
                        await Errorhandle(context);
                        return;
                    }
                    

                        // await _next.Invoke(context);
                        
                        //Start - regarding Rate limiting
                        var endpoint = context.GetEndpoint();

                        // read the LimitRequest attribute from the endpoint
                        var rateLimitDecorator = endpoint?.Metadata.GetMetadata<LimitRequest>();
                        if (rateLimitDecorator is null)
                        {
                            await _next.Invoke(context);
                            return;
                        }
                        //var key = GenerateClientKey(context, user.FirstOrDefault().UserId.ToString());
                        //var _clientStatistics = GetClientStatisticsByKey(key).Result;

                        // Check whether the request violates the rate limit policy

                        //if (_clientStatistics != null
                        //    && DateTime.UtcNow < _clientStatistics.LastSuccessfulResponseTime.AddSeconds(rateLimitDecorator.TimeWindow)
                        //    && _clientStatistics.NumberofRequestsCompletedSuccessfully == rateLimitDecorator.MaxRequests)
                        //{
                        //    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                        //    await Errorhandle(context);
                        //    return;
                        //}
                        //await UpdateClientStatisticsAsync(key, rateLimitDecorator.MaxRequests);
                        await _next.Invoke(context);
                        //End - regarding Rate limiting
                    

                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Unauthorized
                    await Errorhandle(context);
                    return;
                }
            }
            else
            {
                // no authorization header
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; //Unauthorized
                await Errorhandle(context);
                return;
            }

        }
        private async Task Errorhandle(HttpContext context, string ex = "")
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ErrorResponse
            {
                Success = false
            };
            switch (context.Response.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    errorResponse.Message = ErrorMessages.Unauthorized;
                    _logger.LogError(ErrorMessages.Unauthorized);
                    break;
                case (int)HttpStatusCode.Forbidden:
                    errorResponse.Message = ErrorMessages.Forbidden;
                    _logger.LogError(ErrorMessages.Forbidden);
                    break;
                case (int)HttpStatusCode.TooManyRequests:
                    errorResponse.Message = ErrorMessages.TooManyRequests;
                    _logger.LogError(ErrorMessages.TooManyRequests);
                    break;
                default:
                    if (!string.IsNullOrEmpty(ex))
                    {
                        errorResponse.Message = HttpStatusCode.InternalServerError.ToString();
                        _logger.LogError(ex);
                        break;
                    }
                    errorResponse.Message = context.Response.StatusCode.ToString();
                    _logger.LogError(context.Response.StatusCode.ToString());
                    break;
            }

            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
            return;
        }

        /// <summary>
        /// Check user claim has groups
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        /// <summary>
        /// generate ClientKey from the context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string GenerateClientKey(HttpContext context,string userid)
         //=> $"{context.Request.Path}_{context.Connection.RemoteIpAddress}";
         => $"{context.Request.Path}_{userid}";


        /// <summary>
        /// Get the client statistics from caching
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private async Task<ClientStatistics> GetClientStatisticsByKey(string key)
         => await _cache.GetCachedValueAsyn<ClientStatistics>(key);

        private async Task UpdateClientStatisticsAsync(string key, int maxRequests)
        {
            var _clientStats = _cache.GetCachedValueAsyn<ClientStatistics>(key).Result;
            if (_clientStats is not null)
            {
                _clientStats.LastSuccessfulResponseTime = DateTime.UtcNow;
                if (_clientStats.NumberofRequestsCompletedSuccessfully == maxRequests)
                    _clientStats.NumberofRequestsCompletedSuccessfully = 1;
                else
                    _clientStats.NumberofRequestsCompletedSuccessfully++;

                await _cache.SetCachedValueAsync<ClientStatistics>(key, _clientStats);
            }
            else
            {
                var clientStats = new ClientStatistics
                {
                    LastSuccessfulResponseTime = DateTime.UtcNow,
                    NumberofRequestsCompletedSuccessfully = 1
                };

                await _cache.SetCachedValueAsync<ClientStatistics>(key, clientStats);
            }
        }
        
    }
}