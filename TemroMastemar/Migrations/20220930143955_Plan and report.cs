using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class Planandreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plan_and_Report",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plan_or_Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    S_ReportDate = table.Column<int>(type: "int", nullable: true),
                    S_ReportMonth = table.Column<int>(type: "int", nullable: false),
                    S_ReportYear = table.Column<int>(type: "int", nullable: false),
                    E_ReportDate = table.Column<int>(type: "int", nullable: true),
                    E_ReportMonth = table.Column<int>(type: "int", nullable: false),
                    E_ReportYear = table.Column<int>(type: "int", nullable: false),
                    ReportBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Physical_Document = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan_and_Report", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plan_and_Report");
        }
    }
}
