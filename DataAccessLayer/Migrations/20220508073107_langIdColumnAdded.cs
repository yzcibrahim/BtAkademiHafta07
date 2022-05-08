using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class langIdColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "WordDefinitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WordDefinitions_LanguageId",
                table: "WordDefinitions",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_WordDefinitions_Languages_LanguageId",
                table: "WordDefinitions",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordDefinitions_Languages_LanguageId",
                table: "WordDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_WordDefinitions_LanguageId",
                table: "WordDefinitions");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "WordDefinitions");
        }
    }
}
