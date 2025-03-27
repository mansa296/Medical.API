using Medical.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.DTOs.Responses.Users
{
    /// <summary>
    /// The user with roles response class
    /// </summary>
    /// <seealso cref="UserResponseBase"/>
    public class UserWithRolesResponse : UserResponseBase
    {
        /// <summary>
        /// Gets or sets the value of the roles
        /// </summary>
        public IEnumerable<Role> Roles { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="UserWithRolesResponse"/> class
        /// </summary>
        public UserWithRolesResponse()
        {
            Roles = new List<Role>();
            
        }
    }
}
