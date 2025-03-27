namespace Medical.Model.DTOs.Requests.Users
{
    /// <summary>
    /// The update activity status request class
    /// </summary>
    public class UpdateActivityStatusRequest
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        public bool Active { get; set; }
    }
}
