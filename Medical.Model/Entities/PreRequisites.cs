using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class PreRequisites
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string PreRequisitesJson { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public PreRequisites()
        {
            CreatedOn = DateTime.UtcNow;
            IsActive = true;
        }
    }
}
