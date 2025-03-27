using Medical.Domain.TokenDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace Medical.API.Middlewares
{
    /// <summary>
    /// The token authorization middleware class
    /// </summary>
    /// <seealso cref="IAuthorizationMiddlewareResultHandler"/>
    public class TokenAuthorizationMiddleware : IAuthorizationMiddlewareResultHandler
    {
        /// <summary>
        /// The default handler
        /// </summary>
        private readonly AuthorizationMiddlewareResultHandler _defaultHandler;
        /// <summary>
        /// The token domain
        /// </summary>
        private readonly ITokenDomain _tokenDomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenAuthorizationMiddleware"/> class
        /// </summary>
        /// <param name="tokenDomain">The token domain</param>
        public TokenAuthorizationMiddleware(ITokenDomain tokenDomain)
        {
            _defaultHandler = new();
            _tokenDomain = tokenDomain;
        }

        /// <summary>
        /// Handles the next
        /// </summary>
        /// <param name="next">The next</param>
        /// <param name="context">The context</param>
        /// <param name="policy">The policy</param>
        /// <param name="authorizeResult">The authorize result</param>
        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            var isValidToken = await _tokenDomain.IsValidAsync(context.Request.Headers.Authorization);

            if (!isValidToken)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(string.Empty);
                return;
            }

            await _defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
}
