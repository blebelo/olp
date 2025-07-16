using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId1",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId1",
                table: "Instructors",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpUsers_UserId1",
                table: "Instructors",
                column: "UserId1",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpUsers_UserId1",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId1",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Instructors");
        }
    }
}
