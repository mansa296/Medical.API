using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class CloudTransformationHub
    {
        public int Id { get; set; }
        public string? ContentName { get; set; }
        public string? ContentDescription { get; set; }
        public string? ContentThumbnailPath { get; set; }
        public string? ContentUrl { get; set; }
        public bool IsActive { get; set; }
        public int? SequenceOrder { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? ModifiedOn { get; set; }
}
}
