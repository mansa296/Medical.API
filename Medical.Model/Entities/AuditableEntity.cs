namespace Medical.Model.Entities
{
    /// <summary>
    /// The auditable entity class
    /// </summary>
    public class AuditableEntity
    {
        /// <summary>
        /// Gets or sets the value of the created at
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Gets or sets the value of the created by
        /// </summary>
        public int CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets the value of the last modified at
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }
        /// <summary>
        /// Gets or sets the value of the last modified by
        /// </summary>
        public int? LastModifiedBy { get; set; }
    }
}
