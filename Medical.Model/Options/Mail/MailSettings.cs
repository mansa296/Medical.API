namespace Medical.Model.Options.Mail
{
    /// <summary>
    /// The mail settings class
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Gets or sets the value of the mail
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// Gets or sets the value of the display name
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets the value of the password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the value of the host
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Gets or sets the value of the port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Gets or sets the value of IsEnabled
        /// </summary>
        public bool IsEnabled { get; set; }
        /// <summary>
        /// Gets or sets the value of the Subject
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets the value of the Salutation
        /// </summary>
        public string Salutation { get; set; }
        /// <summary>
        /// Gets or sets the value of the FooterMessage
        /// </summary>
        public string FooterMessage { get; set; }
    }
}
