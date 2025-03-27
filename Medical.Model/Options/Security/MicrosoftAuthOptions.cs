namespace Medical.Model.Options.Security
{
    /// <summary>
    /// The microsoft auth options class
    /// </summary>
    public class MicrosoftAuthOptions
    {
        /// <summary>
        /// Gets or sets the value of the tenant id
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Gets or sets the value of the client id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Gets or sets the value of the secret
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Gets or sets the value of the authority
        /// </summary>
        //public string Authority { get; set; }
    }
}

