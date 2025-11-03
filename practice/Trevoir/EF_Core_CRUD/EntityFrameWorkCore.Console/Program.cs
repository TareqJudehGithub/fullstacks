using EntityFrameWorkCore.Data;
using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;


using var context = new FootballLeagueDbContext();



// Insert Data


// Simple Insert
async Task SimpleInsert()
{
    // 1. Create a new record
    var newCoach = new Coach
    {
        Name = "Jose Mourinho",
        Country = "Portugal",
        CreatedDate = DateTime.Today
    };
    // 2. Add the created new object into the database
    await context.Coaches.AddAsync(newCoach);

    // 3. Save changes
    await context.SaveChangesAsync();

    var coaches = await context.Coaches
        .Select(q => q.Name)
        .ToListAsync();

    foreach (var coachName in coaches)
    {
        Console.WriteLine(coachName);
    }
}
// await SimpleInsert();
async Task AddTeams()
{
    var acMilan = new Team
    {
        Id = 1,
        Name = "AC Milan",
        Country = "Italy",
        CreatedDate = new DateTime(year: 2025, month: 10, day: 30),
        CreatedBy = "Admin",
        LeagueId = 1,
        CoachId = 1
    };
    await context.Teams.AddAsync(acMilan);
    //  await context.SaveChangesAsync();

    var interMilan = new Team
    {
        Id = 2,
        Name = "Inter Milan",
        Country = "Italy",
        CreatedDate = new DateTime(year: 2025, month: 9, day: 15),
        CreatedBy = "Admin",
        LeagueId = 1,
        CoachId = 2
    };
    await context.Teams.AddAsync(interMilan);
    // await context.SaveChangesAsync();

    var manUinted = new Team
    {
        Id = 3,
        Name = "Man United",
        Country = "England",
        CreatedDate = new DateTime(year: 2025, month: 11, day: 1),
        CreatedBy = "Admin",
        LeagueId = 2,
        CoachId = 3
    };

    await context.Teams.AddAsync(manUinted);

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    // await context.SaveChangesAsync();

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);

    var teams = await context.Teams
        .Select(q => q.Name)
        .ToListAsync();
    foreach (var team in teams)
    {
        Console.WriteLine(team);
    }
}
//await AddTeams();

// Loop Insert
async Task LoopInsert()
{
    var ancelotti = new Coach
    {
        Name = "Carlo Ancelotti",
        Country = "Italy",
        CreatedDate = DateTime.Today
    };
    var allergri = new Coach
    {
        Name = "Allegri",
        Country = "Italy",
        CreatedDate = DateTime.Today
    };
    List<Coach> coaches = new List<Coach>
    {
        ancelotti,
        allergri
    };

    // Iterate over coaches, and add each item into the DB
    foreach (var coach in coaches)
    {
        await context.Coaches.AddAsync(coach);
    }
    // Check what happens before save
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    Console.Read();
    // Save
    await context.SaveChangesAsync();

    Console.Read();
    // Check what happens after save
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);

}
// await LoopInsert();


// Batch Insert
async Task BatchInsert()
{
    // Create new coach obj
    var ferugson = new Coach
    {
        Name = "Alex Ferugson",
        Country = "England",
        CreatedDate = DateTime.Today
    };
    var enrique = new Coach
    {
        Name = "Luis Enrique",
        Country = "Spain",
        CreatedDate = DateTime.Today
    };

    // Add coach objs to a list of coaches
    List<Coach> coaches = new List<Coach>()
    {
        ferugson,
        enrique
    };
    // Add into the database all new objects and save after that.
    await context.Coaches.AddRangeAsync(coaches);
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    Console.Read();

    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);

    var displayCoaches = await context.Coaches
        .OrderBy(q => q.Name)
        .Select(q => q.Name)
        .ToListAsync();

    foreach (var coachName in displayCoaches)
    {
        Console.WriteLine(coachName);
    }

}
// await BatchInsert();


// Update 
async Task UpdateDbItem()
{
    // FindAsync() tracks the record (param value), and check if it is present, which saves times checking back and forth into the database it self.
    // .FindAsync(Id)
    var allergri = await context.Coaches.FindAsync(7);

    // Making changes
    allergri.Name = "Max Allegri";
    //  Save changes    

    await context.SaveChangesAsync();


    // If tracking was disabled:
    var deleteCoach = await context.Coaches
        .AsNoTracking()
        .FirstOrDefaultAsync(q => q.Id == 13);

    // Make your changes 
    deleteCoach.Name = "Delete me!";
    deleteCoach.Country = "And me!";

    // Update and save DB
    context.Update(deleteCoach);
    await context.SaveChangesAsync();

    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await UpdateDbItem();


// Delete records
async Task DeleteItems()
{
    var coach = await context.Coaches.FindAsync(10);
    context.Remove(coach);
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.SaveChangesAsync();


}
// await DeleteItems();


//  Another way to del: Execute delete  - one line, no context.SaveChangesAsync();  so be careful.
async Task ExecuteDelete()
{
    var coach = await context.Coaches
        .Where(q => q.Id == 9)
        .ExecuteDeleteAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await ExecuteDelete();

// Execute Update - updating rec alt

async Task ExecuteUpdate()
{
    var carlo = await context.Coaches
        .Where(q => q.Id == 6)
        .ExecuteUpdateAsync(set => set
        .SetProperty(prop => prop.Name, "Carlo Ancelotti")
        .SetProperty(prop => prop.Country, "Italia")
        );
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await ExecuteUpdate();

async Task InsertNewTeam()
{
    var newTeam = new Team
    {
        Name = "Inter Milan",
        Country = "Italy",
        CreatedBy = "Admin",
        CreatedDate = DateTime.Today
    };

    var teams = await context.Teams.AddAsync(newTeam);
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    await context.SaveChangesAsync();

}
//await InsertNewTeam();



// Sec7: Lecture 77 - Insert Related Data

// Insert record with FK

// Insert match
async Task InsertNewMatch()
{
    var match1 = new Match
    {
        HomeTeamId = 11,
        AwayTeamId = 12,
        HomeTeamScore = 2,
        AwayTeamScore = 0,
        Country = "Italy",
        Date = new DateTime(2025, 11, 14),
        CreatedDate = DateTime.Today,
        CreatedBy = "Admin",
        TicketPrice = 20,
    };

    await context.AddAsync(match1);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await InsertNewMatch();

// Insert Parent/Child
async Task AddingParentAndChild()
{
    // First, we create a new coach obj, and add it into Context.
    var pepGuardiola = new Coach
    {
        Name = "Pep Guardiola",
        Country = "Spain",
        CreatedDate = DateTime.Today,
        CreatedBy = "Admin"
    };
    await context.Coaches.AddAsync(pepGuardiola);
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);

    // Then, we create a new team, and add the newly created coach obj into it.
    Console.WriteLine("Press any key to continue");
    Console.Read();
    var barcelona = new Team
    {
        Name = "Barcelona",
        CoachId = 16,
        CreatedDate = DateTime.Today,
        CreatedBy = "Admin",
        LeagueId = 3,
    };
    await context.AddAsync(barcelona);

    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
//await AddingParentAndChild();

// Updating missing properties
async Task UpdateTeam()
{
    var barcelona = await context.Teams.FindAsync(17);
    barcelona.Country = "Spain";


    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await UpdateTeam();


// Insert Parent with Children
// Adding a new league and new teams same time..

async Task AddLeagueAndTeam()
{

    var primeiraLiga = new League
    {
        Name = "Primeira Liga",
        Country = "Portugal",
        Teams = new List<Team>
            {
                new Team
                {
                    Name = "Benfica",
                    Country = "Portugal",
                    CreatedDate = DateTime.Today,
                    CreatedBy = "Admin",
                    CoachId = 17
                },
                 new Team
                {
                    Name = "Porto",
                    Country = "Portugal",
                    CreatedDate = DateTime.Today,
                    CreatedBy = "Admin",
                    CoachId = 18
                },
                  new Team
                {
                    Name = "Sporting",
                    Country = "Portugal",
                    CreatedDate = DateTime.Today,
                    CreatedBy = "Admin",
                    CoachId = 19
                }
            },
    };
    await context.Leagues.AddAsync(primeiraLiga);
    await context.SaveChangesAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
await AddLeagueAndTeam();
