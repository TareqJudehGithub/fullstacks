namespace EntityFrameWorkCore.Domain
{
    public class Team : BaseDomainModel
    {
        #region Properties       
        public string? Name { get; set; }
        public int CoachId { get; set; }


        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }


        // League navigation property of type League
        public League? League { get; set; }
        public int? LeagueId { get; set; } // FK for League table 
        #endregion
    }
}
