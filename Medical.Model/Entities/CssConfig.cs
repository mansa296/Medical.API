using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class CssConfig
    {
        public int CssConfigId { get; set; }
        public string CssConfigName { get; set; }
        public string CssConfigContent { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
