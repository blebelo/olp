using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class RestructuredLessonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_StudentProgresses_StudentProgressId",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_StudentProgresses_StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttempts_StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_StudentProgressId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "Lessons");

            migrationBuilder.AddColumn<Guid[]>(
                name: "CompletedLessonIds",
                table: "StudentProgresses",
                type: "uuid[]",
                nullable: true);

            migrationBuilder.AddColumn<Guid[]>(
                name: "CompletedQuizIds",
                table: "StudentProgresses",
                type: "uuid[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedLessonIds",
                table: "StudentProgresses");

            migrationBuilder.DropColumn(
                name: "CompletedQuizIds",
                table: "StudentProgresses");

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "QuizAttempts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "Lessons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_StudentProgressId",
                table: "QuizAttempts",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentProgressId",
                table: "Lessons",
                column: "StudentProgressId");

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
        }
    }
}
