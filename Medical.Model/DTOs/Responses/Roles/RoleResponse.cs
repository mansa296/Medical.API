namespace Medical.Model.DTOs.Responses.Roles
{
    /// <summary>
    /// The role response class
    /// </summary>
    public class RoleResponse
    {
        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}