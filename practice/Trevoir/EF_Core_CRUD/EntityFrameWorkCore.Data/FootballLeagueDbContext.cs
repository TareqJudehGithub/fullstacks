using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EntityFrameWorkCore.Data
{
    public class FootballLeagueDbContext : DbContext
    {
        // DbSets (entities)
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<League> Leagues { get; set; }

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
            // Look for any/ALL IEntityTypeConfiguration<> Interface in 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Or one by one
            //modelBuilder.ApplyConfiguration(new TeamConfiguration());
            //modelBuilder.ApplyConfiguration(new LeagueConfiguration());


        }
    }
}
