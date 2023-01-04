using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class VideoandAudioUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Videos",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Audios",
                newName: "Path");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Videos",
                newName: "Document");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Audios",
                newName: "Document");
        }
    }
}
