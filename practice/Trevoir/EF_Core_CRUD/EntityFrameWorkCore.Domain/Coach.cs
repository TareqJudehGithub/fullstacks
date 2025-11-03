namespace EntityFrameWorkCore.Domain
{
    public class Coach : BaseDomainModel
    {
        #region Properties
        public string? Name { get; set; }
        public Team? Team { get; set; }
        #endregion
    }
}
