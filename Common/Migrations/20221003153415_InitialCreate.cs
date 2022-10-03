using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPApp.Common.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rules = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinNumOfPlayers = table.Column<int>(type: "int", nullable: false),
                    MaxNumOfPlayers = table.Column<int>(type: "int", nullable: false),
                    MinPalyerAge = table.Column<int>(type: "int", nullable: false),
                    PlayingTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
