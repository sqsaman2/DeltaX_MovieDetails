using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Version3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Producer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Producer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Producer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Producer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PosterId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Actor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Actor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Actor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Actor_Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actor_Movie_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actor_Movie_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentLength = table.Column<long>(type: "bigint", nullable: false),
                    ContentByte = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_PosterId",
                table: "Movie",
                column: "PosterId");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_Movie_ActorId",
                table: "Actor_Movie",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actor_Movie_MovieId",
                table: "Actor_Movie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Image_PosterId",
                table: "Movie",
                column: "PosterId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Image_PosterId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Actor_Movie");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Movie_PosterId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Producer");

            migrationBuilder.DropColumn(
                name: "PosterId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Actor");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Actor");
        }
    }
}
