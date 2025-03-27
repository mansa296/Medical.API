namespace Medical.Model.DTOs.Requests.Users
{
    /// <summary>
    /// The update user request class
    /// </summary>
    public class UpdateUserRequest
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; } 
        /// <summary>
        /// Gets or sets the value of the first name
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the value of the last name
        /// </summary>
        public string Mobile { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        public bool IsApprove { get; set; }
    }
}
