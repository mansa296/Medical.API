using Medical.Model.Entities;

namespace Medical.Repository.TokenRepository
{
    /// <summary>
    /// The token repository interface
    /// </summary>
    public interface ITokenRepository
    {
        /// <summary>
        /// Gets the by value using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>A task containing the token</returns>
        Task<Token?> GetByValueAsync(string value);
        /// <summary>
        /// Creates the token
        /// </summary>
        /// <param name="token">The token</param>
        Task CreateAsync(Token token);

        Task UpdateAsync(Token token);
    }
}