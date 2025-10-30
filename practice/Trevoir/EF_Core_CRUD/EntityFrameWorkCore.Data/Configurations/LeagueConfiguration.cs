using EntityFrameWorkCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityFrameWorkCore.Data.Configurations
{
    internal class LeagueConfiguration : IEntityTypeConfiguration<League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.HasData(
            new League
            {
                Id = 1,
                Name = "Serie A",
                Country = "Italy",
                CreatedDate = DateTime.Today,
                CreatedBy = "Admin"
            },
             new League
             {
                 Id = 2,
                 Name = "EPL",
                 Country = "England",
                 CreatedDate = DateTime.Today,
                 CreatedBy = "Admin"
             },
              new League
              {
                  Id = 3,
                  Name = "La Liga",
                  Country = "Spain",
                  CreatedDate = DateTime.Today,
                  CreatedBy = "Admin"
              },
               new League
               {
                   Id = 4,
                   Name = "Ligue 1",
                   Country = "France",
                   CreatedDate = DateTime.Today,
                   CreatedBy = "Admin"
               },
                new League
                {
                    Id = 5,
                    Name = "Eredivisie",
                    Country = "Netherlands",
                    CreatedDate = DateTime.Today,
                    CreatedBy = "Admin"
                },
                 new League
                 {
                     Id = 6,
                     Name = "Bundesliga",
                     Country = "Germany",
                     CreatedDate = DateTime.Today,
                     CreatedBy = "Admin"
                 }
                );
        }
    }
}
