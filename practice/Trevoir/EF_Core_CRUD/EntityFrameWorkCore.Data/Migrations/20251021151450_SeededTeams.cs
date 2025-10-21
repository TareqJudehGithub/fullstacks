using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameWorkCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Country", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Italy", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "AC Milan" },
                    { 2, "Italy", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Inter Milan" },
                    { 3, "Italy", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Juventus" },
                    { 4, "England", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Manchester United" },
                    { 5, "England", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Manchester City" },
                    { 6, "England", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Chelsea" },
                    { 7, "England", new DateTime(2025, 10, 21, 0, 0, 0, 0, DateTimeKind.Local), "Liverpool" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
