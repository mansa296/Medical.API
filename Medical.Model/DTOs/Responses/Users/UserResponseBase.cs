namespace Medical.Model.DTOs.Responses.Users
{
    /// <summary>
    /// The user response base class
    /// </summary>
    public class UserResponseBase
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the value of the last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the value of the country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserResponseBase"/> class
        /// </summary>
        public UserResponseBase()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Country = string.Empty;
            Active = false;
        }
    }
}
