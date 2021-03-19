using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class ChangeInBoothClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterScores_Games_RegisterScoreId",
                table: "RegisterScores");

            migrationBuilder.DropIndex(
                name: "IX_RegisterScores_RegisterScoreId",
                table: "RegisterScores");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "RegisterScores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "RegisterScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScores_RegisterScoreId",
                table: "RegisterScores",
                column: "RegisterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterScores_Games_RegisterScoreId",
                table: "RegisterScores",
                column: "RegisterScoreId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
