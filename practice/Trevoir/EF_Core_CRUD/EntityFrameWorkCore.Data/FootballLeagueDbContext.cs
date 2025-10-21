using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        // DbSets
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        // Connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=TareqPC\\MSSQLSRV; Database=FootballLeague_Practice; Encrypt=False; Integrated Security=True; TrustServerCertificate=True;"
            );

            // Seeding (inserting data) into FootballLeague_Practice DB  tables
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "AC Milan",
                    Country = "Italy",
                    CreatedDate = DateTime.Today
                },
                 new Team
                 {
                     Id = 2,
                     Name = "Inter Milan",
                     Country = "Italy",
                     CreatedDate = DateTime.Today
                 },
                  new Team
                  {
                      Id = 3,
                      Name = "Juventus",
                      Country = "Italy",
                      CreatedDate = DateTime.Today
                  },
                   new Team
                   {
                       Id = 4,
                       Name = "Manchester United",
                       Country = "England",
                       CreatedDate = DateTime.Today
                   },
                    new Team
                    {
                        Id = 5,
                        Name = "Manchester City",
                        Country = "England",
                        CreatedDate = DateTime.Today
                    },
                     new Team
                     {
                         Id = 6,
                         Name = "Chelsea",
                         Country = "England",
                         CreatedDate = DateTime.Today
                     },
                      new Team
                      {
                          Id = 7,
                          Name = "Liverpool",
                          Country = "England",
                          CreatedDate = DateTime.Today
                      }
                );

        }
    }
}
