using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addedInstructorRolePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rolesId",
                table: "Instructors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_rolesId",
                table: "Instructors",
                column: "rolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpRoles_rolesId",
                table: "Instructors",
                column: "rolesId",
                principalTable: "AbpRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpRoles_rolesId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_rolesId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "rolesId",
                table: "Instructors");
        }
    }
}
