using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.EF.Domain
{
    public class GetUserDetails
    {
        [Key]
        public int UserBusinessUnitMappingId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public Guid BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public string BusinessUnitPrefix { get; set; }
        public Guid? GroupId { get; set; }
        public int RoleId { get; set; }
        public string CoreName { get; set; }
        public bool IsActive { get; set; }
    }
}
