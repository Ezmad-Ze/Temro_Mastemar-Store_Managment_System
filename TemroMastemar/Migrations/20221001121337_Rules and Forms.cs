using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class RulesandForms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    FormID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormDate = table.Column<int>(type: "int", nullable: true),
                    FormMonth = table.Column<int>(type: "int", nullable: true),
                    FormYear = table.Column<int>(type: "int", nullable: true),
                    FormBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Physical_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.FormID);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    RuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RuleDate = table.Column<int>(type: "int", nullable: true),
                    RuleMonth = table.Column<int>(type: "int", nullable: true),
                    RuleYear = table.Column<int>(type: "int", nullable: true),
                    RuleBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Physical_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.RuleID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Rules");
        }
    }
}
