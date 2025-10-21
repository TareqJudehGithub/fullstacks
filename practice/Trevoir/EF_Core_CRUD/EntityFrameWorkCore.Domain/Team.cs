namespace EntityFrameWorkCore.Domain
{
    public class Team : BaseDomainModel
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        #endregion
    }
}
