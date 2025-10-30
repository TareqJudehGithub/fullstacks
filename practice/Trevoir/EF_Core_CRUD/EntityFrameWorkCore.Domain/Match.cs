using EntityFrameWorkCore.Domain;

public class Match : BaseDomainModel
{
    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; }
    public decimal TicketPrice { get; set; }
    public DateTime Date { get; set; }

    //  Navigation properties
    public Team HomeTeam { get; set; }
    public int HomeTeamId { get; set; }  // FK

    public Team AwayTeam { get; set; }
    public int AwayTeamId { get; set; } // FK


}
