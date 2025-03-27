using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class PreRequisitesJson
    {
        public int AssetId { get; set; }
        public string suscription_id { get; set; }
        public string TARGET_RESOURCE_GROUP_NAME { get; set; }
        public string mig_prjname { get; set; }
        public string Target_Machine { get; set; }

        public PreRequisitesJson() { 
            suscription_id = string.Empty;
            TARGET_RESOURCE_GROUP_NAME = string.Empty;
            mig_prjname = string.Empty;
            Target_Machine = string.Empty;
        }
        // public virtual IList<Control> Control { get; set; }

    }
    public class Control
    {
       
    }
}
