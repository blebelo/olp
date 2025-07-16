using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpRoles_rolesId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpUsers_UserAccountId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_rolesId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserAccountId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "rolesId",
                table: "Instructors");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Instructors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpUsers_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpUsers_UserId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instructors");

            migrationBuilder.AddColumn<long>(
                name: "UserAccountId",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "rolesId",
                table: "Instructors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_rolesId",
                table: "Instructors",
                column: "rolesId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserAccountId",
                table: "Instructors",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpRoles_rolesId",
                table: "Instructors",
                column: "rolesId",
                principalTable: "AbpRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpUsers_UserAccountId",
                table: "Instructors",
                column: "UserAccountId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }
    }
}
