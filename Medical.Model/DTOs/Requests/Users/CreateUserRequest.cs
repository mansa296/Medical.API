using System.Text.Json.Serialization;

namespace Medical.Model.DTOs.Requests.Users
{
    /// <summary>
    /// The create user request class
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// The is create
        /// </summary>
        protected bool _isCreate = true;
        /// <summary>
        /// Gets the value of the is create
        /// </summary>
        public bool IsCreate => _isCreate;

        /// <summary>
        /// Gets or sets the value of the first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the value of the last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the roles
        /// </summary>
        public int[] Roles { get; set; }
        /// <summary>
        /// Gets or sets the value of the password
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        [JsonIgnore] public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the value of the country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRequest"/> class
        /// </summary>
        public CreateUserRequest()
        {
            FirstName = string.Empty;
            LastName = string.Empty; 
            Email = string.Empty;
            Roles = Array.Empty<int>();
            Active = true;
            Country = string.Empty;
        }
    }
}
