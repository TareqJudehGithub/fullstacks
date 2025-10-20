using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Data
{
    // Properties
    public class FootballLeagueDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQL Server                                            
            optionsBuilder.UseSqlServer("Server=TareqPC\\MSSQLSRV; Database=FootballLeague_EFCore; Encrypt=False; Integrated Security=True; TrustServerCertificate=True;");

            // SQL Lite
            //optionsBuilder.UseSqlite("Data Source=(); Initial Catalog=FootballLeague_EFCore; Encrypt=False; ");
        }

        // Seeding DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    TeamId = 1,
                    Name = "Man United",
                    CreatedDate = DateTimeOffset.UtcNow.DateTime
                },
                   new Team
                   {
                       TeamId = 2,
                       Name = "Man City",
                       CreatedDate = DateTimeOffset.UtcNow.DateTime
                   },
                      new Team
                      {
                          TeamId = 3,
                          Name = "Liverpool",
                          CreatedDate = DateTimeOffset.UtcNow.DateTime
                      },
                        new Team
                        {
                            TeamId = 4,
                            Name = "Chelsea",
                            CreatedDate = DateTimeOffset.UtcNow.DateTime
                        }
                );
        }
    }
}
