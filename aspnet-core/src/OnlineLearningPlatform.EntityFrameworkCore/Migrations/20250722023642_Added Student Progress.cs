using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_Quizzes_QuizId",
                table: "QuizAttempt");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempt_Students_StudentId",
                table: "QuizAttempt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt");

            migrationBuilder.RenameTable(
                name: "QuizAttempt",
                newName: "QuizAttempts");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempt_StudentId",
                table: "QuizAttempts",
                newName: "IX_QuizAttempts_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempt_QuizId",
                table: "QuizAttempts",
                newName: "IX_QuizAttempts_QuizId");

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

            migrationBuilder.AddColumn<Guid>(
                name: "StudentProgressId",
                table: "QuizAttempts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempts",
                table: "QuizAttempts",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Score = table.Column<int>(type: "integer", nullable: false),
                    CorrectAnswers = table.Column<string[]>(type: "text[]", nullable: true),
                    IncorrectAnswers = table.Column<string[]>(type: "text[]", nullable: true),
                    QuizAttemptId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Result_QuizAttempts_QuizAttemptId",
                        column: x => x.QuizAttemptId,
                        principalTable: "QuizAttempts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentProgresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentName = table.Column<string>(type: "text", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProgresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_QuizAttempts_StudentProgressId",
                table: "QuizAttempts",
                column: "StudentProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_QuizAttemptId",
                table: "Result",
                column: "QuizAttemptId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProgresses_StudentId",
                table: "StudentProgresses",
                column: "StudentId");

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
                name: "FK_QuizAttempts_Quizzes_QuizId",
                table: "QuizAttempts",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempts_StudentProgresses_StudentProgressId",
                table: "QuizAttempts",
                column: "StudentProgressId",
                principalTable: "StudentProgresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempts_Students_StudentId",
                table: "QuizAttempts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_QuizAttempts_Quizzes_QuizId",
                table: "QuizAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_StudentProgresses_StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizAttempts_Students_StudentId",
                table: "QuizAttempts");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "StudentProgresses");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizAttempts",
                table: "QuizAttempts");

            migrationBuilder.DropIndex(
                name: "IX_QuizAttempts_StudentProgressId",
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

            migrationBuilder.DropColumn(
                name: "StudentProgressId",
                table: "QuizAttempts");

            migrationBuilder.RenameTable(
                name: "QuizAttempts",
                newName: "QuizAttempt");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempts_StudentId",
                table: "QuizAttempt",
                newName: "IX_QuizAttempt_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizAttempts_QuizId",
                table: "QuizAttempt",
                newName: "IX_QuizAttempt_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizAttempt",
                table: "QuizAttempt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_Quizzes_QuizId",
                table: "QuizAttempt",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAttempt_Students_StudentId",
                table: "QuizAttempt",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
