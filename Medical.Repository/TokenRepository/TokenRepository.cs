using Medical.Infrastructure.Persistence.UnitOfWork;
using Medical.Model.Entities;
using Dapper;

namespace Medical.Repository.TokenRepository
{
    /// <summary>
    /// The token repository class
    /// </summary>
    /// <seealso cref="ITokenRepository"/>
    public class TokenRepository : ITokenRepository
    {
        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenRepository"/> class
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public TokenRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the by value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>A task containing the token</returns>
        public async Task<Token?> GetByValueAsync(string value)
        {
            return await _unitOfWork.Connection
                .QueryFirstOrDefaultAsync<Token>(TokenQueries.GetByValue, new { value }, _unitOfWork.Transaction);
        }

        /// <summary>
        /// Creates the token
        /// </summary>
        /// <param name="token">The token</param>
        public async Task CreateAsync(Token token)
        {
            await _unitOfWork.Connection.ExecuteAsync(TokenQueries.Insert, token, _unitOfWork.Transaction);
        }

        public async Task UpdateAsync(Token token)
        {
            await _unitOfWork.Connection.ExecuteAsync(TokenQueries.UpdateTokenStatus, token, _unitOfWork.Transaction);
        }
    }
}
