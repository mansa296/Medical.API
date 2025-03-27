namespace Medical.Infrastructure.Integration.Tools.IntegrationTokenProvider.Model
{
    /// <summary>
    /// The fetched token
    /// </summary>
    public struct FetchedToken
    {
        /// <summary>
        /// Gets the value of the token
        /// </summary>
        public string Token { get; }
        /// <summary>
        /// Gets the value of the valid to
        /// </summary>
        public DateTime ValidTo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FetchedToken"/> class
        /// </summary>
        /// <param name="token">The token</param>
        /// <param name="validTo">The valid to</param>
        public FetchedToken(string token, DateTime validTo)
        {
            Token = token;
            ValidTo = validTo;
        }
    }
}
