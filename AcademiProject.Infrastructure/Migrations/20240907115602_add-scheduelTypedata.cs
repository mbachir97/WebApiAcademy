using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryPaternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class addscheduelTypedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "FRI", "MON", "SAT", "SUN", "ScheduleType", "THU", "TUE", "WED" },
                values: new object[,]
                {
                    { 1, false, true, false, true, "Daily", true, true, true },
                    { 2, false, false, false, true, "DayAfterDay", true, true, false },
                    { 3, false, true, false, false, "TwiceAWeek", false, false, true },
                    { 4, true, false, true, false, "Weekend", false, false, false },
                    { 5, true, true, true, true, "Compact", true, true, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
