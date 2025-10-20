using EntityFrameworkCore.Data;
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


