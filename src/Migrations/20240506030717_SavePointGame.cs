using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SavePointAPI.Migrations
{
    /// <inheritdoc />
    public partial class SavePointGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavePointNotes");
            migrationBuilder.CreateTable(
                name: "SavePointGames",
                columns: table => new
                {
                    SavePointGameId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameName = table.Column<string>(type: "text", nullable: true),
                    GameConsole = table.Column<string>(type: "text", nullable: true),
                    GameGenre = table.Column<string>(type: "text", nullable: true),
                    GameDeveloper = table.Column<string>(type: "text", nullable: true),
                    GamePublisher = table.Column<string>(type: "text", nullable: true),
                    GameReleaseDate = table.Column<string>(type: "text", nullable: true),
                    GameDescription = table.Column<string>(type: "text", nullable: true),
                    GameRating = table.Column<string>(type: "text", nullable: true),
                    GameImage = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavePointGames", x => x.SavePointGameId);
                });

            migrationBuilder.CreateTable(
                name: "SavePointNotes",
                columns: table => new
                {
                    SavePointNoteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "text", nullable: true),
                    NoteDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SavePointGameId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavePointNotes", x => x.SavePointNoteId);
                    table.ForeignKey(
                        name: "FK_SavePointNotes_SavePointGames_SavePointGameId",
                        column: x => x.SavePointGameId,
                        principalTable: "SavePointGames",
                        principalColumn: "SavePointGameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavePointNotes_SavePointGameId",
                table: "SavePointNotes",
                column: "SavePointGameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavePointNotes");

            migrationBuilder.DropTable(
                name: "SavePointGames");
        }
    }
}
