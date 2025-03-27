using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class DashboardHelp
    {
        public int DashboardHelpId { get; set; }
        public string DashboardHelpTitle { get; set; }
        public string DashboardHelpContent { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
