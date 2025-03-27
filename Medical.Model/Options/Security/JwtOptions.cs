namespace Medical.Model.Options.Security
{
    /// <summary>
    /// The jwt options class
    /// </summary>
    public class JwtOptions
    {
        /// <summary>
        /// Gets or sets the value of the secret
        /// </summary>
        public string Secret { get; set; }
        public string OtpSecret { get; set; }
        /// <summary>
        /// Gets or sets the value of the expire in minutes
        /// </summary>
        public int ExpireInMinutes { get; set; }
        public int OtpExpireInMinutes { get; set; }
        /// <summary>
        /// Gets or sets the value of the audience
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or sets the value of the issuer
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="JwtOptions"/> class
        /// </summary>
        public JwtOptions()
        {
            Secret = string.Empty;
            Audience = string.Empty;
            Issuer = string.Empty;
        }
    }
}