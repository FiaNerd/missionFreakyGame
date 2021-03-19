using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class ChangesInClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "RegisterScores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterScores_RegisterScoreId",
                table: "RegisterScores",
                column: "RegisterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId",
                principalTable: "RegisterScores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisterScores_Games_RegisterScoreId",
                table: "RegisterScores",
                column: "RegisterScoreId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisterScores_Games_RegisterScoreId",
                table: "RegisterScores");

            migrationBuilder.DropIndex(
                name: "IX_RegisterScores_RegisterScoreId",
                table: "RegisterScores");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "RegisterScores");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
