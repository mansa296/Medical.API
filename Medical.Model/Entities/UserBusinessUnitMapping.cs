using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class UserBusinessUnitMapping
    {
        /// <summary>
        /// Gets or sets the value of the role id
        /// </summary>
        public int UserBusinessUnitMappingId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public Guid BusinessUnitId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public bool IsPrimaryBusinessUnit { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class
        /// </summary>
        public UserBusinessUnitMapping()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }
    }
}
