namespace Medical.Model.DTOs.Requests.Users
{
    /// <summary>
    /// The update country request class
    /// </summary>
    public class UpdateCountryRequest
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the country
        /// </summary>
        public string Country { get; set; }
    }
}
