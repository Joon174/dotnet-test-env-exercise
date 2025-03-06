using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StewChessExample.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChessGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WhitePlayerName = table.Column<string>(type: "text", nullable: false),
                    BlackPlayerName = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChessGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PieceMoveEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Piece = table.Column<string>(type: "text", nullable: false),
                    FromPosition = table.Column<string>(type: "text", nullable: false),
                    ToPosition = table.Column<string>(type: "text", nullable: false),
                    Turn = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChessGameEventId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PieceMoveEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PieceMoveEvents_ChessGames_ChessGameEventId",
                        column: x => x.ChessGameEventId,
                        principalTable: "ChessGames",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PieceMoveEvents_ChessGameEventId",
                table: "PieceMoveEvents",
                column: "ChessGameEventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PieceMoveEvents");

            migrationBuilder.DropTable(
                name: "ChessGames");
        }
    }
}
