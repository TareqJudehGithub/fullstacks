using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameWorkCore.Data.Configurations
{
    internal class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            builder.HasData(
                new Coach
                {
                    Id = 1,
                    Name = "Carlo Ancelotti",
                    Country = "Italy",
                    CreatedDate = new DateTime(2025, 10, 30),
                    CreatedBy = "Admin",
                },
                  new Coach
                  {
                      Id = 2,
                      Name = "Jose Morinho",
                      Country = "Portugal",
                      CreatedDate = new DateTime(2025, 10, 30),
                      CreatedBy = "Admin",
                  },
                    new Coach
                    {
                        Id = 3,
                        Name = "Sir Alex Ferugson",
                        Country = "England",
                        CreatedDate = new DateTime(2025, 10, 30),
                        CreatedBy = "Admin",
                    }
                );
        }
    }
}
