
namespace Medical.Model.Options.Security
{    /// <summary>
     /// The Azure AdN options class
     /// </summary>
    public class AzureAdN
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
        public string Instance { get; set; }
        /// <summary>
        /// Gets or sets the value of the authority
        /// </summary>
        public bool AllowWebApiToBeAuthorizedByACL { get; set; }
        /// <summary>
        /// Gets or sets the value of the authority
        /// </summary>
        public string GraphResourceId { get; set; }
        /// <summary>
        /// Gets or sets the value of the authority
        /// </summary>
        public string MicrosoftLogin { get; set; }
        /// <summary>
        /// Gets or sets the value of the authority
        /// </summary>
        public string ClientSecret { get; set; }
    }
}
