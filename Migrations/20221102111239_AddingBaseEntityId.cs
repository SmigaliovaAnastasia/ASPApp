using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPApp.Migrations
{
    public partial class AddingBaseEntityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GamesGameId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenresGenreId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GameSeriesId",
                table: "GameSeries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Games",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenresGenreId",
                table: "GameGenre",
                newName: "GenresId");

            migrationBuilder.RenameColumn(
                name: "GamesGameId",
                table: "GameGenre",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenresGenreId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenresId");

            migrationBuilder.RenameColumn(
                name: "ComplexityLevelId",
                table: "ComplexityLevels",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Games_GamesId",
                table: "GameGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_GameGenre_Genres_GenresId",
                table: "GameGenre");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GameSeries",
                newName: "GameSeriesId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Games",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GameGenre",
                newName: "GenresGenreId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameGenre",
                newName: "GamesGameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                newName: "IX_GameGenre_GenresGenreId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ComplexityLevels",
                newName: "ComplexityLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Games_GamesGameId",
                table: "GameGenre",
                column: "GamesGameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameGenre_Genres_GenresGenreId",
                table: "GameGenre",
                column: "GenresGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
