using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ActorId",
                table: "Movie",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ProducerId",
                table: "Movie",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Producer_ProducerId",
                table: "Movie",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Actor_ActorId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Producer_ProducerId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ActorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_ProducerId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
