using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonneltestingHRCR.Migrations
{
    /// <inheritdoc />
    public partial class UpdDBResultDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultTestId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResultTests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fullname = table.Column<string>(type: "text", nullable: false),
                    IdTest = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultTests", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_ResultTests_ResultTestId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "ResultTests");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ResultTestId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ResultTestId",
                table: "Questions");
        }
    }
}
