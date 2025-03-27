using Medical.Data.EF.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medical.Data.EF.Domain
{
    /// <summary>
    /// The location class
    /// </summary>
    /// <seealso cref="IEntity"/>
    [Table("Locations")]
    public class Location : IEntity
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Column("LocationId")]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class
        /// </summary>
        public Location()
        {
            Name=string.Empty;
        }
    }
}
