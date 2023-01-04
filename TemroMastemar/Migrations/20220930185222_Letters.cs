using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class Letters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    LetterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LetterTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LetterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_LetterDate = table.Column<int>(type: "int", nullable: true),
                    S_LetterMonth = table.Column<int>(type: "int", nullable: false),
                    S_LetterYear = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Physical_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.LetterID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letters");
        }
    }
}
