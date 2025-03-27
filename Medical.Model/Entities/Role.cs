namespace Medical.Model.Entities
{
    /// <summary>
    /// The role class
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string CoreName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class
        /// </summary>
        public Role()
        {
            Name = string.Empty; 
            CoreName = string.Empty;
        }
    }
}
