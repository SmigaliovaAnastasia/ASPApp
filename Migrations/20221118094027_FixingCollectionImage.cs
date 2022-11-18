using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPApp.Migrations
{
    public partial class FixingCollectionImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgImageUrl",
                table: "Collections",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Collections",
                newName: "ImgImageUrl");
        }
    }
}
