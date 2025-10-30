namespace EntityFrameWorkCore.Domain
{
    public class BaseDomainModel
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
