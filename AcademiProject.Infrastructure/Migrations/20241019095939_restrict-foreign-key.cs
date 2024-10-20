using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryPaternWithUOW.EF.Migrations
{
    /// <inheritdoc />
    public partial class restrictforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 16);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 3);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 4);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 5);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 6);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 7);

            //migrationBuilder.DeleteData(
            //    table: "Courses",
            //    keyColumn: "Id",
            //    keyValue: 8);

            //migrationBuilder.DeleteData(
         
     
            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections");

            //migrationBuilder.InsertData(
            //    table: "Courses",
            //    columns: new[] { "Id", "CourseName", "HoursToComplete", "Price" },
            //    values: new object[,]
            //    {
            //        { 1, "Flutter", 50, 3669m },
            //        { 2, "CS50", 50, 3669m },
            //        { 3, "tsql", 50, 3669m },
            //        { 4, "Microsoft 365", 50, 3669m },
            //        { 5, "data Scientist ", 50, 3669m },
            //        { 6, "Network Security ", 50, 3669m },
            //        { 7, "Artificial Intelligence", 50, 3669m },
            //        { 8, "Machine Learning", 50, 3669m },
            //        { 9, "Frontend Engineer(Angular)", 50, 3669m },
            //        { 10, "Frontend Engineer(React)", 50, 3669m },
            //        { 11, "Operating Systems", 50, 3669m },
            //        { 12, ".NET Backend Engineer", 50, 3669m },
            //        { 13, "Database Administrator", 50, 3669m },
            //        { 14, "ASP.NET Full Stack Web Development", 50, 3669m },
            //        { 15, "Object Oriented Design & Analysis", 50, 3669m }
            //    });

            migrationBuilder.AddForeignKey(
                name: "FK_Sections_Courses_CourseId",
                table: "Sections",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
