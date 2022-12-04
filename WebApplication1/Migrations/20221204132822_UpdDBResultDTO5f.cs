using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBResultDTO5f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResult_QuestionResults_QuestionResultID",
                table: "AnswerResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerResult",
                table: "AnswerResult");

            migrationBuilder.RenameTable(
                name: "AnswerResult",
                newName: "AnswerResults");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResult_QuestionResultID",
                table: "AnswerResults",
                newName: "IX_AnswerResults_QuestionResultID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerResults",
                table: "AnswerResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResults_QuestionResults_QuestionResultID",
                table: "AnswerResults",
                column: "QuestionResultID",
                principalTable: "QuestionResults",
                principalColumn: "QuestionResultID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerResults_QuestionResults_QuestionResultID",
                table: "AnswerResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerResults",
                table: "AnswerResults");

            migrationBuilder.RenameTable(
                name: "AnswerResults",
                newName: "AnswerResult");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerResults_QuestionResultID",
                table: "AnswerResult",
                newName: "IX_AnswerResult_QuestionResultID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerResult",
                table: "AnswerResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerResult_QuestionResults_QuestionResultID",
                table: "AnswerResult",
                column: "QuestionResultID",
                principalTable: "QuestionResults",
                principalColumn: "QuestionResultID");
        }
    }
}
