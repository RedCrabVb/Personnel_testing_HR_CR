using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBResultDTO3f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionResult_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResult_ResultTests_ResultTestId",
                table: "QuestionResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResult",
                table: "QuestionResult");

            migrationBuilder.RenameTable(
                name: "QuestionResult",
                newName: "QuestionResults");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionResult_ResultTestId",
                table: "QuestionResults",
                newName: "IX_QuestionResults_ResultTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResults",
                table: "QuestionResults",
                column: "QuestionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionResults_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID",
                principalTable: "QuestionResults",
                principalColumn: "QuestionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResults_ResultTests_ResultTestId",
                table: "QuestionResults",
                column: "ResultTestId",
                principalTable: "ResultTests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionResults_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionResults_ResultTests_ResultTestId",
                table: "QuestionResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionResults",
                table: "QuestionResults");

            migrationBuilder.RenameTable(
                name: "QuestionResults",
                newName: "QuestionResult");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionResults_ResultTestId",
                table: "QuestionResult",
                newName: "IX_QuestionResult_ResultTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionResult",
                table: "QuestionResult",
                column: "QuestionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionResult_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID",
                principalTable: "QuestionResult",
                principalColumn: "QuestionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionResult_ResultTests_ResultTestId",
                table: "QuestionResult",
                column: "ResultTestId",
                principalTable: "ResultTests",
                principalColumn: "Id");
        }
    }
}
