using Medical.Repository.TokenRepository;

namespace Medical.Domain.TokenDomain
{
    /// <summary>
    /// The token domain class
    /// </summary>
    /// <seealso cref="ITokenDomain"/>
    public class TokenDomain : ITokenDomain
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly ITokenRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenDomain"/> class
        /// </summary>
        /// <param name="repository">The repository</param>
        public TokenDomain(ITokenRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Ises the valid using the specified token
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> IsValidAsync(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var result = await _repository.GetByValueAsync(token.Replace("Bearer", "", StringComparison.OrdinalIgnoreCase).Trim());

                if (result is not null)
                {
                    return !result.IsLoggedOut;
                }
            }

            return false;
        }
    }
}
