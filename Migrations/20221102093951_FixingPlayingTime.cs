using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPApp.Migrations
{
    public partial class FixingPlayingTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayingTime",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "maxPlayingTimeMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minPlayingTimeMinutes",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "maxPlayingTimeMinutes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "minPlayingTimeMinutes",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "PlayingTime",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
