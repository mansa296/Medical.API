using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.EF.Domain
{
    /// <summary>
    /// The link class
    /// </summary>
    /// <seealso cref="IEntity"/>
    public class Link : IEntity
    {
        /// <summary>
        /// Gets or sets the value of the id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the value of the json report id
        /// </summary>
        public int JsonReportId { get; set; }
        /// <summary>
        /// Gets or sets the value of the txture id
        /// </summary>
        public string TxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the type name
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Gets or sets the value of the source asset txture id
        /// </summary>
        public string SourceAssetTxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the target asset txture id
        /// </summary>
        public string TargetAssetTxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the target asset txture id
        /// </summary>
        public Guid? BusinessUnitId { get; set; }
        public  DateTime? CreatedOn { get; set; }
        public  DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
