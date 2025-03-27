using Medical.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.DTOs.Responses.Users
{
    public class UserBusinessUnitResponse
    {
        /// <summary>
        /// Gets or sets the value of the user id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the value of the email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets the value of the full name
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Gets or sets the value of the First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the value of the Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the value of the roles
        /// </summary>
        public IEnumerable<string> Roles { get; set; }

        /// <summary>
        /// Gets or sets the List of the businessUnitMasters
        /// </summary>
        public IEnumerable<BusinessUnitMaster> BusinessUnitMasters { get; set; }
        /// <summary>
        /// Gets or sets the value of the active
        /// </summary>
        public bool Active { get; set; }
        /// <summary>
        /// Gets or sets the List of the memberfirm
        /// </summary>
        public IEnumerable<BusinessUnitMaster> MemberFirm { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticateResponse"/> class
        /// </summary>
        public UserBusinessUnitResponse()
        {
            Email = string.Empty;
            FullName = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Roles = new List<string>();
            Active = false;
        }

    }
}
