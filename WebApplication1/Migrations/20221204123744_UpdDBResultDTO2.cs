using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBResultDTO2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ResultTests_ResultTestId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ResultTestId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ResultTestId",
                table: "Questions");

            migrationBuilder.AddColumn<int>(
                name: "QuestionResultID",
                table: "Answers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuestionResult",
                columns: table => new
                {
                    QuestionResultID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    AnswerQ = table.Column<string>(type: "text", nullable: false),
                    ResultTestId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionResult", x => x.QuestionResultID);
                    table.ForeignKey(
                        name: "FK_QuestionResult_ResultTests_ResultTestId",
                        column: x => x.ResultTestId,
                        principalTable: "ResultTests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionResult_ResultTestId",
                table: "QuestionResult",
                column: "ResultTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionResult_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID",
                principalTable: "QuestionResult",
                principalColumn: "QuestionResultID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionResult_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropTable(
                name: "QuestionResult");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionResultID",
                table: "Answers");

            migrationBuilder.AddColumn<int>(
                name: "ResultTestId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ResultTestId",
                table: "Questions",
                column: "ResultTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_ResultTests_ResultTestId",
                table: "Questions",
                column: "ResultTestId",
                principalTable: "ResultTests",
                principalColumn: "Id");
        }
    }
}
