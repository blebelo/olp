using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFKFromNavigationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId1",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId2",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentProgresses_StudentProgressId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_StudentProgresses_StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentProgresses_Students_StudentId",
                table: "StudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_StudentProgresses_StudentId",
                table: "StudentProgresses");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttempts_StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_StudentProgressId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentProgressId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentProgressId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentProgressId2",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentProgressId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentProgressId2",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "StudentProgresses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "StudentProgresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "StudentProgresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "StudentProgresses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentProgresses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "StudentProgresses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "StudentProgresses",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentProgresses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "QuizAttempts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "Lessons",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId1",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId2",
                table: "Courses",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresses_StudentId",
                table: "StudentProgresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_StudentProgressId",
                table: "QuizAttempts",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentProgressId",
                table: "Lessons",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentProgressId",
                table: "Courses",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentProgressId1",
                table: "Courses",
                column: "StudentProgressId1");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentProgressId2",
                table: "Courses",
                column: "StudentProgressId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId",
                table: "Courses",
                column: "StudentProgressId",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId1",
                table: "Courses",
                column: "StudentProgressId1",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_StudentProgresses_StudentProgressId2",
                table: "Courses",
                column: "StudentProgressId2",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_StudentProgresses_StudentProgressId",
                table: "Lessons",
                column: "StudentProgressId",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempts_StudentProgresses_StudentProgressId",
                table: "QuizAttempts",
                column: "StudentProgressId",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentProgresses_Students_StudentId",
                table: "StudentProgresses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
