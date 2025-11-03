namespace EntityFrameWorkCore.Domain
{
    public class Team : BaseDomainModel
    {
        #region Properties       
        public string? Name { get; set; }
        // Navigation property - Coach
        public Coach Coach { get; set; }
        public int CoachId { get; set; }


        public List<Match> HomeMatches { get; set; } = new List<Match>() { };
        public List<Match> AwayMatches { get; set; } = new List<Match>() { };

        // League navigation property of type League
        public League? League { get; set; }
        public int? LeagueId { get; set; } // FK for League table 

        #endregion
    }
}
