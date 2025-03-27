using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public  class BusinessUnitMaster
    {
        /// <summary>
        /// Gets or sets the value of the BusinessUnitId
        /// </summary>
        public Guid BusinessUnitId { get; set; }
        /// <summary>
        /// Gets or sets the value of the BusinessUnitName
        /// </summary>
        public string BusinessUnitName { get; set; }
        /// <summary>
        /// Gets or sets the value of the BusinessUnitPrefix
        /// </summary>
        public string BusinessUnitPrefix { get; set; }
        /// <summary>
        /// Gets or sets the value of the BusinessUnitPrefix
        /// </summary>
        public bool? IsPrimaryBusinessUnit { get; set; }

        public  DateTime? CreatedOn { get; set; }
        public  DateTime? ModifiedOn { get; set; }

        public Guid? GroupId { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitMaster"/> class
        /// </summary>
        public BusinessUnitMaster()
        {
            BusinessUnitId = default;
            BusinessUnitName = string.Empty;
            BusinessUnitPrefix=string.Empty;
            GroupId = Guid.Empty;
        }
    }
}
