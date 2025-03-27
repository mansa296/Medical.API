namespace Medical.Domain.TokenDomain
{
    /// <summary>
    /// The token domain interface
    /// </summary>
    public interface ITokenDomain
    {
        /// <summary>
        /// Ises the valid using the specified token
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>A task containing the bool</returns>
        Task<bool> IsValidAsync(string token);
    }
}