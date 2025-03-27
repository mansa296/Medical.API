namespace Medical.Data.EF.Domain
{
    public interface IBaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
