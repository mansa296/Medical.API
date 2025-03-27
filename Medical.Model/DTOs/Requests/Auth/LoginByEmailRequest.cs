namespace Medical.Model.DTOs.Requests.Auth
{
    /// <summary>
    /// The login by email request class
    /// </summary>
    public class LoginByEmailRequest
    {
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the password
        /// </summary>
        public string Password { get; set; }
    }
}
