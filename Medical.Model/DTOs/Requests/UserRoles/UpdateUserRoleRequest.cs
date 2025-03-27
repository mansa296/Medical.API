namespace Medical.Model.DTOs.Requests.UserRoles
{
    /// <summary>
    /// The update user role request class
    /// </summary>
    public class UpdateUserRoleRequest
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        public int RoleId { get; set; }
    }
}
