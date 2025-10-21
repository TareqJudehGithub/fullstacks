namespace EntityFrameWorkCore.Domain
{
    public class Coach : BaseDomainModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        #endregion
    }
}
