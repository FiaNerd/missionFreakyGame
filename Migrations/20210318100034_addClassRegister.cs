using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreakyGame.Migrations
{
    public partial class addClassRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterScoreId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameRegister",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Game = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRegister", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_GameRegister_RegisterScoreId",
                table: "Games",
                column: "RegisterScoreId",
                principalTable: "GameRegister",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_GameRegister_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameRegister");

            migrationBuilder.DropIndex(
                name: "IX_Games_RegisterScoreId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RegisterScoreId",
                table: "Games");
        }
    }
}
