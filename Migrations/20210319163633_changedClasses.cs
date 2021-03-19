using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class changedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameRegister_GameRegister_RegisterScoreId",
                table: "GameRegister");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameRegister",
                table: "GameRegister");

            migrationBuilder.DropIndex(
                name: "IX_GameRegister_RegisterScoreId",
                table: "GameRegister");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "GameRegister");

            migrationBuilder.RenameTable(
                name: "GameRegister",
                newName: "RegisterScores");

            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegisterScores",
                table: "RegisterScores",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegisterScores",
                table: "RegisterScores");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "RegisterScores",
                newName: "GameRegister");

            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "GameRegister",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameRegister",
                table: "GameRegister",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameRegister_RegisterScoreId",
                table: "GameRegister",
                column: "RegisterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameRegister_GameRegister_RegisterScoreId",
                table: "GameRegister",
                column: "RegisterScoreId",
                principalTable: "GameRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
