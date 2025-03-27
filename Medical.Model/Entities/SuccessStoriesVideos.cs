using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class SuccessStoriesVideos
    {
        
        public int Id { get; set; }
        public string VideoName { get; set; }
        public string VideoDescription { get; set; }
        public string VideoThumbnailPath { get; set; }
        public string VideoURL { get; set; }
        public bool IsActive { get; set; }
        public int SequenceOrder { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
    }
}
