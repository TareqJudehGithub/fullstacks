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


// Execute delete  - one line, no context.SaveChangesAsync();  so be careful.
async Task ExecuteDelete()
{
    var coach = await context.Coaches
        .Where(q => q.Id == 9)
        .ExecuteDeleteAsync();
    Console.WriteLine(context.ChangeTracker.DebugView.LongView);
}
// await ExecuteDelete();

// Execute Update

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
await InsertNewTeam();