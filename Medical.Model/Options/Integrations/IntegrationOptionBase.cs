namespace Medical.Model.Options.Integrations
{
    /// <summary>
    /// The integration option base class
    /// </summary>
    public abstract class IntegrationOptionBase
    {
        /// <summary>
        /// Gets or sets the value of the base url
        /// </summary>
        public string BaseURL { get; set; }
        /// <summary>
        /// Gets or sets the value of the system user
        /// </summary>
        public SystemUser SystemUser { get; set; }
    }
}