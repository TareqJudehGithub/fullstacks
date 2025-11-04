namespace EntityFrameWorkCore.Domain
{
    public class League : BaseDomainModel
    {
        public string? Name { get; set; }
        // League has many teams: one to many (1 league many teams)
        public List<Team>? Teams { get; set; } = new List<Team> { };
    }
}
