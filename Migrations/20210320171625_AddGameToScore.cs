using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class AddGameToScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "RegisterScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScores_GameId",
                table: "RegisterScores",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterScores_Games_GameId",
                table: "RegisterScores",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisterScores_Games_GameId",
                table: "RegisterScores");

            migrationBuilder.DropIndex(
                name: "IX_RegisterScores_GameId",
                table: "RegisterScores");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "RegisterScores");

            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Games_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId",
                principalTable: "RegisterScores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
