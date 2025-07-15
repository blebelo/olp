using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class RefactoredInstructorEntityExtendsPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Instructors",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Instructors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Instructors",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Instructors",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
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

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Instructors",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserAccountId",
                table: "Instructors",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserAccountId",
                table: "Instructors",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_AbpUsers_UserAccountId",
                table: "Instructors",
                column: "UserAccountId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_AbpUsers_UserAccountId",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserAccountId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Instructors");
        }
    }
}
