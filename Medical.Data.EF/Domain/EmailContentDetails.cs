using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Data.EF.Domain
{
    public class EmailContentDetails : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int EmailId { get;set; }
        public Guid? BusinessUnitId { get; set; }
        public string EmailCategoryType { get; set; }
        public string EmailCategoryDescription { get; set; }
        public string? EmailTo { get; set; }
        public string? EmailSubject { get; set; }
        public string? EmailHtmlBody { get; set; }
        public string? EmailRegards { get; set; }
        public string? EmailHeaderImage { get; set; }
        public string? EmailFooterImage { get; set; }
        public bool? IsApproveOption { get; set; }
        public bool? IsACtive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string? CreatedByUserName { get; set; }
        public string? ModifiedByUserName { get; set; }
    }
}
