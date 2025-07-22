using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Instructors_InstructorId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_InstructorId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Lessons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Lessons",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_InstructorId",
                table: "Lessons",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Instructors_InstructorId",
                table: "Lessons",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }
    }
}
