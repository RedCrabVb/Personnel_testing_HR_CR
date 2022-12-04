using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdQuestionForDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Tests_TestEntityId",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Question",
                table: "Question");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answer",
                table: "Answer");

            migrationBuilder.RenameTable(
                name: "Question",
                newName: "Questions");

            migrationBuilder.RenameTable(
                name: "Answer",
                newName: "Answers");

            migrationBuilder.RenameIndex(
                name: "IX_Question_TestEntityId",
                table: "Questions",
                newName: "IX_Questions_TestEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuestionID",
                table: "Answers",
                newName: "IX_Answers_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questions",
                table: "Questions",
                column: "QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answers",
                table: "Answers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers",
                column: "QuestionID",
                principalTable: "Questions",
                principalColumn: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestEntityId",
                table: "Questions",
                column: "TestEntityId",
                principalTable: "Tests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestEntityId",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questions",
                table: "Questions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Answers",
                table: "Answers");

            migrationBuilder.RenameTable(
                name: "Questions",
                newName: "Question");

            migrationBuilder.RenameTable(
                name: "Answers",
                newName: "Answer");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_TestEntityId",
                table: "Question",
                newName: "IX_Question_TestEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionID",
                table: "Answer",
                newName: "IX_Answer_QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Question",
                table: "Question",
                column: "QuestionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Answer",
                table: "Answer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Tests_TestEntityId",
                table: "Question",
                column: "TestEntityId",
                principalTable: "Tests",
                principalColumn: "Id");
        }
    }
}
