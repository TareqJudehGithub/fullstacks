using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //  role
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "983d9c8d-349e-4c18-b048-dfc931a5e0ad",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
               new IdentityRole
               {
                   Id = "025c7db8-1398-4ad7-8a99-b0b54ad2b041",
                   Name = "Supervisor",
                   NormalizedName = "SUPERVISOR"
               },
               new IdentityRole
               {
                   Id = "6e81b54c-4570-4258-959e-44f479777a27",
                   Name = "Administration",
                   NormalizedName = "ADMINISTRATION"
               }
                );

            // User - admin
            // Password hasher
            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "7aff287c-da05-49de-ae97-b5741d160c3f",
                    Email = "admin.adams@gmail.com",
                    NormalizedEmail = "ADMIN.ADAMS@GMAIL.COM",
                    UserName = "sarah.adams",
                    NormalizedUserName = "SARAH.ADAMS",
                    PasswordHash = hasher.HashPassword(null, "Pa$$@"),
                    EmailConfirmed = true
                }
                );
            // User roles
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "6e81b54c-4570-4258-959e-44f479777a27",
                    UserId = "7aff287c-da05-49de-ae97-b5741d160c3f"
                }
                );
        }

        // Entities
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
