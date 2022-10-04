using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPApp.Common.Migrations
{
    public partial class TimestampToRowVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Games",
                newName: "RowVersion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowVersion",
                table: "Games",
                newName: "Timestamp");
        }
    }
}
