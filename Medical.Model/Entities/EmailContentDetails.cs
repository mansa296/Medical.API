using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.Entities
{
    public class EmailContentDetails
    {
        
        public int Id { get; set; }
        public string EmailSubject { get; set; }
        public string EmailHtmlBody { get; set; }
        public string EmailRegards { get; set; }
        public string EmailHeaderImage { get; set; }
        public string EmailFooterImage { get; set; }
        public bool IsApproveOption { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
