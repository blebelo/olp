using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class ImplementedInstructorToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Instructors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Instructors",
                type: "text",
                nullable: true);
        }
    }
}
