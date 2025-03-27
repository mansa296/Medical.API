using Medical.Model.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.DTOs.Requests.Users
{
    public class AddUpdateUserBusinessUnitRequest
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the roles
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the list of attachments
        /// </summary>
        public List<BusinessUnitMasterRequest> BusinessUnits { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddCommentRequest"/> class
        /// </summary>
        //public AddUpdateUserBusinessUnitRequest()
        //{
        //    BusinessUnits = new List<BusinessUnitMaster>();
        //}
    }
    public class BusinessUnitMasterRequest
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
        public bool? isChecked { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessUnitMaster"/> class
        /// </summary>
        public BusinessUnitMasterRequest()
        {
            BusinessUnitId = default;
            BusinessUnitName = string.Empty;
            BusinessUnitPrefix = string.Empty;


        }
    }
}
