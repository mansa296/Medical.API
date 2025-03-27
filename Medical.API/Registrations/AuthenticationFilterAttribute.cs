using Medical.Common;
using Medical.Model.DTOs.Responses;
using Medical.Model.Entities;
using Medical.Model.Options.Security;
using Medical.Repository.UserRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace Medical.API.Registrations
{
    public class AuthenticationFilterAttribute : Attribute, IAuthorizationFilter
    {
        private readonly JwtOptions _jwtOptions;
        
        /// <summary>
        /// The user repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        /// <summary>
        /// The tenant repository
        /// </summary>
        public AuthenticationFilterAttribute(IOptions<JwtOptions> securityOptions,
                    
                    IUserRepository userRepository
        )
        {
            _jwtOptions = securityOptions.Value;
            
            _userRepository = userRepository;
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var errorResponse = new ErrorResponse
            {
                Success = false
            };

            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            StringValues headerValues;
            var BusinessUnitId = default(Guid);
            if (context.HttpContext.Request.Headers.TryGetValue("X-Custom-BusinessUnitId", out headerValues))
            {

                BusinessUnitId = Guid.Parse(headerValues.FirstOrDefault());
            }

            if (string.IsNullOrEmpty(authHeader))
            {
                context.Result = new UnauthorizedResult();
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
                    //var user = (await _businessUnitRepository.GetUserByBUEmailAsync(BusinessUnitId.ToString(), email.Value));
                    
                    //if (user != null)
                    //{
                    //    if (user.FirstOrDefault()?.Active != true)
                    //    {
                    //        context.Result = new UnauthorizedResult();
                    //        //return;
                    //    }
                    //}
                    
                }
                catch (Exception ex)
                {
                    context.Result = new UnauthorizedResult();
                    //return;
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
               // return;
            }
           
        }

    }
    
}
