using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class DataObject
    {
        /// <summary>
        /// Gets or sets the value of the data object id
        /// </summary>
        public int DataObjectId { get; set; }
        /// <summary>
        /// Gets or sets the value of the txture id
        /// </summary>
        public string TxtureId { get; set; }
        /// <summary>
        /// Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the value of the confidentiality level id
        /// </summary>
        public int ConfidentialityLevelId { get; set; }
        /// <summary>
        /// Gets or sets the value of the personal data
        /// </summary>
        public bool PersonalData { get; set; }

        
        /// <summary>
        /// Gets or sets the value of the storages
        /// </summary>
        public List<Storage> Storages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataObject"/> class
        /// </summary>
        public DataObject()
        {
            Name = string.Empty;
            Description = string.Empty;

            
            Storages = new List<Storage>();
        }
    }
}
