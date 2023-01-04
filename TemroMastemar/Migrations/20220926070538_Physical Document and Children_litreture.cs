using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class PhysicalDocumentandChildren_litreture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Physical_Document",
                table: "Literatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "C_Literatures",
                columns: table => new
                {
                    C_LiteratureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    C_LiteratureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_LiteratureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_LiteratureFor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WrittenMonth = table.Column<int>(type: "int", nullable: true),
                    WrittenYear = table.Column<int>(type: "int", nullable: true),
                    C_Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    C_Physical_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C_Literatures", x => x.C_LiteratureID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C_Literatures");

            migrationBuilder.DropColumn(
                name: "Physical_Document",
                table: "Literatures");
        }
    }
}
