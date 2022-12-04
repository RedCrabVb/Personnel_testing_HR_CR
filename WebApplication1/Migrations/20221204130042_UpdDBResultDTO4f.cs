using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBResultDTO4f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_QuestionResults_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionResultID",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionResultID",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "QuestionResults",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "AnswerResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    QuestionResultID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerResult_QuestionResults_QuestionResultID",
                        column: x => x.QuestionResultID,
                        principalTable: "QuestionResults",
                        principalColumn: "QuestionResultID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerResult_QuestionResultID",
                table: "AnswerResult",
                column: "QuestionResultID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerResult");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "QuestionResults",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionResultID",
                table: "Answers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_QuestionResults_QuestionResultID",
                table: "Answers",
                column: "QuestionResultID",
                principalTable: "QuestionResults",
                principalColumn: "QuestionResultID");
        }
    }
}
