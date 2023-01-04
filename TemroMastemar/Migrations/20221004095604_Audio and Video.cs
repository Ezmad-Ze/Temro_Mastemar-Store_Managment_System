using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class AudioandVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    AudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioDate = table.Column<int>(type: "int", nullable: true),
                    AudioMonth = table.Column<int>(type: "int", nullable: false),
                    AudioYear = table.Column<int>(type: "int", nullable: false),
                    AudioBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.AudioID);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoDate = table.Column<int>(type: "int", nullable: true),
                    VideoMonth = table.Column<int>(type: "int", nullable: false),
                    VideoYear = table.Column<int>(type: "int", nullable: false),
                    VideoBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
