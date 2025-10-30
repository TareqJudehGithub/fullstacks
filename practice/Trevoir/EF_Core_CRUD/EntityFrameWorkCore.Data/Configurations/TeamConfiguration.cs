using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityFrameWorkCore.Data.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // No two teams should have the same name
            builder.HasIndex(q => q.Name).IsUnique();

            // Home   -  On to Many relationship
            builder
                //  Team has many home matches  
                .HasMany(m => m.HomeMatches)
                // Home matches mapped to the home team
                .WithOne(q => q.HomeTeam)
                // map the FK which is HomeTeamId
                .HasForeignKey(q => q.HomeTeamId)
                .IsRequired()
                // On delete - Do not allow team deletion that has related matches
                .OnDelete(DeleteBehavior.Restrict);

            // Away -  On to Many relationship
            // Away team has many matches
            builder
                .HasMany(m => m.AwayMatches)
                .WithOne(q => q.AwayTeam)
                .HasForeignKey(q => q.AwayTeamId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                 new Team
                 {
                     Id = 1,
                     Name = "AC Milan",
                     Country = "Italy",
                     CreatedDate = new DateTime(year: 2025, month: 10, day: 30),
                     CreatedBy = "Admin"
                 },
                     new Team
                     {
                         Id = 2,
                         Name = "Inter Milan",
                         Country = "Italy",
                         CreatedDate = new DateTime(2025, 10, 30),
                         CreatedBy = "Admin"
                     },
                      new Team
                      {
                          Id = 3,
                          Name = "Juventus",
                          Country = "Italy",
                          CreatedDate = new DateTime(2025, 10, 30),
                          CreatedBy = "Admin"
                      },
                       new Team
                       {
                           Id = 4,
                           Name = "Manchester United",
                           Country = "England",
                           CreatedDate = new DateTime(2025, 10, 30),
                           CreatedBy = "Admin"
                       },
                        new Team
                        {
                            Id = 5,
                            Name = "Manchester City",
                            Country = "England",
                            CreatedDate = new DateTime(2025, 10, 30),
                            CreatedBy = "Admin"
                        },
                         new Team
                         {
                             Id = 6,
                             Name = "Chelsea",
                             Country = "England",
                             CreatedDate = new DateTime(2025, 10, 30),
                             CreatedBy = "Admin"
                         },
                          new Team
                          {
                              Id = 7,
                              Name = "Liverpool",
                              Country = "England",
                              CreatedDate = new DateTime(2025, 10, 30),
                              CreatedBy = "Admin"
                          }
                );
        }

    }
}
