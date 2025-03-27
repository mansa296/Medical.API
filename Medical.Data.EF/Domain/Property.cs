using System.ComponentModel.DataAnnotations;

namespace Medical.Data.EF.Domain
{
    /// <summary>
    /// The property class
    /// </summary>
    /// <seealso cref="IEntity"/>
    public class Property : IEntity,IBaseEntity
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the asset id
        /// </summary>
        public int AssetId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the value of the value
        /// </summary>
        public Guid BusinessUnitId { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}