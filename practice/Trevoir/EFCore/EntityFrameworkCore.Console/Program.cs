using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

// Create new instance of context - FootballLeagueDbContext
using var context = new FootballLeagueDbContext();


// Select * from Teams
async Task GetAllTeams()
{
    // Create an object of Teams class
    // Look/(get the) at the Teams, convert it to List, then we can start querying.

    var teams = await context.Teams.ToListAsync();
    foreach (var item in teams)
    {
        Console.WriteLine(item.Name);
    }

    //return await $"Teams List:\n{GetAllTeams()}";
    // Console.WriteLine($"Teams List:\n{GetAllTeams()}");
    // Call or get all teams
    // GetAllTeams();
}
await GetAllTeams();

Console.WriteLine("\n");

async Task GetOneTeam()
{
    // Selecting a single record - returns the 1st item found in the list.
    var team = context.Teams.FirstOrDefault(team => team.TeamId == 1);

    if (team != null)
    {
        Console.WriteLine(team.TeamId + " " + team.Name);

    }
    var team2 = await context.Teams.FirstOrDefaultAsync(team => team.TeamId == 5);

    //if (team2 != null)
    //{
    //    Console.WriteLine(team2.Name);
    //}

    var team2Name = team2 != null ? team2.Name : "No team found";
    Console.WriteLine(team2Name);

    var team3 = await context.Teams.FindAsync(3);

    if (team3 != null)
    {
        Console.WriteLine(team3.Name);
    }


    // Select items that meet a condition
    var teamsFiltered = await context.Teams.Where(q => q.Name == "Man City").ToListAsync();
    foreach (var item in teamsFiltered)
    {
        Console.WriteLine(item.Name);
    }
    await GetOneTeam();

}
async Task GetFilteredTeams()
{
    Console.Write("Team name: ");
    var desiredTeam = Console.ReadLine();

    // Search by Team
    var userChoice = await context.Teams.Where(q => q.Name == desiredTeam).ToListAsync();
    foreach (var item in userChoice)
    {
        Console.WriteLine(item.Name);

    }

    // Input contains:
    Console.Write("Search teams... ");
    var userInput = Console.ReadLine();
    var searchResult = await context.Teams.Where(q => q.Name.Contains(userInput)).ToListAsync();

    // Using EF function
    var searchResult2 = await context.Teams.Where(q => EF.Functions.Like(q.Name, $"%{userInput}%")).ToListAsync();


    foreach (var item in searchResult2)
    {
        if (item.Name.Contains(userInput))
        {
            Console.WriteLine($"Found team: {item.Name}");
        }
        else
        {
            Console.WriteLine("No team match!");
        }
    }

}
await GetFilteredTeams();

void TestCompare()
{
    var firstName = "John";
    string compareName = "Sarah";

    var isSameName = string.Equals(firstName, compareName, StringComparison.OrdinalIgnoreCase);
    Console.WriteLine(isSameName);
}
TestCompare();

async Task GetAllTeamsAltSync()
{
    // This is like reversed SQL syntax lol confusing?!
    var teams = from team in context.Teams select team;
}

await GetAllTeamsAltSync();


// Aggregate Methods
Console.WriteLine("\nAggregate Functions");
async Task AggregateMethods()
{
    // Count or CountAsync  - Counts total items inside a table object
    var numberOfTeams = await context.Teams.CountAsync();
    var numberOfTeamsFiltered = await context.Teams.CountAsync(q => q.Name.Contains("Man"));

    // Max value
    var maxTeamId = await context.Teams.MaxAsync(q => q.TeamId);
    // Min  value
    var minTeamId = await context.Teams.MinAsync(q => q.TeamId);

    // Average
    var avgTeamId = await context.Teams.AverageAsync(q => q.TeamId);

    // Sum
    var sumOfTeamId = await context.Teams.SumAsync(q => q.TeamId);


    Console.WriteLine($"No. of teams: {numberOfTeams}");
    Console.WriteLine($" Contains word 'Man': {numberOfTeamsFiltered}");
    Console.WriteLine($"Max Id: {maxTeamId}");
    Console.WriteLine($"Min Id: {minTeamId}");
    Console.WriteLine($"Avg Team ID: {avgTeamId}");
    Console.WriteLine($"Sum of IDs: {sumOfTeamId}");

    // Grouping and Aggregating  - Group by a specific column
    Console.WriteLine("\nGroup By");
    var groupedTeams = context.Teams
        .GroupBy(q => new { q.CreatedDate.Date });

    foreach (var group in groupedTeams)
    {
        Console.WriteLine($"group.Key: {group.Key}");
        Console.Write("Group by Sum: ");
        Console.WriteLine(group.Sum(q => q.TeamId));
        foreach (var team in group)
        {
            Console.WriteLine(team.Name);
        }
    }

    // Order By - rearrange the order the table items would be presented
    Console.WriteLine("\nOrder By");
    var orderedTeams = await context.Teams
        .OrderBy(q => q.Name)
        .ToListAsync();

    foreach (var team in orderedTeams)
    {
        Console.WriteLine(team.Name);
    }

    // Order by - Descending
    Console.WriteLine("\nOrder By - Descending");
    var orderedTeamsDesc = await context.Teams
        .OrderByDescending(q => q.Name)
        .ToListAsync();

    foreach (var team in orderedTeamsDesc)
    {
        Console.WriteLine(team.Name);
    }

    // Skip and Take  - skip x numbers of records, and take x numbers of records
    // Displays certain amount of data based on the Skip() and the Take() methods.
    async Task SkipAndTake()
    {
        Console.WriteLine("\nSkip and Take");
        var recordCount = 3;
        var page = 0;
        var next = true;

        while (next)
        {
            var teams = await context.Teams
                    .Skip(page * recordCount)
                    .Take(recordCount)
                    .ToListAsync();

            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
            }
            Console.Write("Continue? (true/false): ");
            next = Convert.ToBoolean(Console.ReadLine());

            // Break the loop
            if (!next) { break; }

            // Or, increment by 1
            page += 1;

        }


    }
    //    await SkipAndTake();


    // Select
    Console.WriteLine("Press any key to continue");

    Console.Clear();

    async Task Select()
    {

        Console.WriteLine("Select() - Press any key to continue");
        var teamNames = await context.Teams
            .OrderBy(q => q.Name)
            .Select(q => q.Name)
            .ToListAsync();

        foreach (var team in teamNames)
        {
            Console.WriteLine(team);
        }

        // Return more than one column using Select()
        var teamsIdAndName = await context.Teams
            .OrderBy(q => q.TeamId)
            .Select(q => new { q.TeamId, q.Name })
            .ToListAsync();

        foreach (var team in teamsIdAndName)
        {
            Console.WriteLine($"ID: {team.TeamId} Name: {team.Name}");
        }
        Console.WriteLine("\nProjections:");
        // Create a list of TeamInfo objects 
        var teamsInfo = await context.Teams
            .OrderBy(q => q.TeamId)
            .Select(q => new TeamInfo
            {
                TeamInfoID = q.TeamId,
                TeamInfoName = q.Name
            })
            .ToListAsync();

        foreach (var team in teamsInfo)
        {
            Console.WriteLine($"ID: {team.TeamInfoID} Name: {team.TeamInfoName}");
        }
    }
    await Select();

}
await AggregateMethods();
Console.Clear();
async Task IQueryAbleTypes()
{
    // Console.WriteLine("IQueryable types");

    Console.Write("(1). Team with Id 1.  (2) for teams that contain AC: ");

    int userChoice = Convert.ToInt32(Console.ReadLine());

    //var userChoice = 2;
    // Creating a new list of Teams generic type
    List<Team> teamsAsList = new List<Team>();

    // Fill the teamsAsList with items from Teams view model
    teamsAsList = await context.Teams.ToListAsync();

    // Replace data in teamsAsList according to the userChoice:
    if (userChoice == 1)
    {
        teamsAsList = teamsAsList
            .Where(q => q.TeamId == 1)
            .ToList();
    }
    else if (userChoice == 2)
    {
        teamsAsList = teamsAsList
            .Where(q => q.Name.Contains("AC"))
            .ToList();
    }
    foreach (var team in teamsAsList)
    {
        Console.WriteLine(team.Name);
    }



    Console.Write("(1).  (2) for teams AC: IQueryable: ");

    userChoice = Convert.ToInt32(Console.ReadLine());
    // IQueryable
    var teamsAsQueryable = context.Teams.AsQueryable();
    if (userChoice == 1)
    {
        teamsAsQueryable = teamsAsQueryable
            .Where(q => q.TeamId == 1);
    }
    else if (userChoice == 2)
    {
        teamsAsQueryable = teamsAsQueryable
            .Where(q => q.Name.Contains("AC"));
    }

    // Convert from IQueryable to a List

    List<Team> teamsAsListV2 = new List<Team>();
    teamsAsListV2 = await teamsAsQueryable.ToListAsync();

    foreach (var team in teamsAsListV2)
    {
        Console.WriteLine(team.Name);
    }






}
await IQueryAbleTypes();


class TeamInfo
{
    #region Properties
    public int TeamInfoID { get; set; }
    public string TeamInfoName { get; set; }
    #endregion
}

