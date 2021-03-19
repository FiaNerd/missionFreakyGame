using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class ChangesInClassesTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_RegisterScores_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId",
                principalTable: "RegisterScores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
