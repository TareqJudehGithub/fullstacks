using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForIdentityAddingSarahAdAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "025c7db8-1398-4ad7-8a99-b0b54ad2b041", null, "Supervisor", "SUPERVISOR" },
                    { "6e81b54c-4570-4258-959e-44f479777a27", null, "Administration", "ADMINISTRATION" },
                    { "983d9c8d-349e-4c18-b048-dfc931a5e0ad", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7aff287c-da05-49de-ae97-b5741d160c3f", 0, "c148a38c-7884-44b4-80e5-6b12dc082022", "admin.adams@gmail.com", true, false, null, "ADMIN.ADAMS@GMAIL.COM", "SARAH.ADAMS", "AQAAAAIAAYagAAAAEH4RZ3h270AAfjuUMamlMIoxW2BnlXRgjjAa3nSJGpNOInenaVCjbzO5XeBTwTXDUw==", null, false, "31ccd528-c13f-473f-97a0-e71ad271c103", false, "sarah.adams" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6e81b54c-4570-4258-959e-44f479777a27", "7aff287c-da05-49de-ae97-b5741d160c3f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "025c7db8-1398-4ad7-8a99-b0b54ad2b041");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "983d9c8d-349e-4c18-b048-dfc931a5e0ad");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e81b54c-4570-4258-959e-44f479777a27", "7aff287c-da05-49de-ae97-b5741d160c3f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e81b54c-4570-4258-959e-44f479777a27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aff287c-da05-49de-ae97-b5741d160c3f");
        }
    }
}
