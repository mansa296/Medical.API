namespace Medical.Model.Entities
{
    /// <summary>
    /// The token class
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Gets or sets the value of the token id
        /// </summary>
        public int TokenId { get; set; }
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the value of the is logged out
        /// </summary>
        public bool IsLoggedOut { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class
        /// </summary>
        public Token()
        {
            Value = string.Empty;
        }
    }
}
