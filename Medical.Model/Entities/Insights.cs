using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class Insights
    {
        public int Id { get; set; }
        public string InsightsName { get; set; }
        public string InsightsThumbnail { get; set; }
        public string InsightsContent { get; set; }
        public string InsightsURL { get; set; }
        public bool IsActive { get; set; }
        public int SequenceOrder { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}
