using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandFather_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mother_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Babtisal_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<int>(type: "int", nullable: true),
                    MonthofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearofBirth = table.Column<int>(type: "int", nullable: true),
                    PlaceofBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marital_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Woreda = table.Column<int>(type: "int", nullable: true),
                    House_Number = table.Column<int>(type: "int", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education_Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Current_Committee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Committe_Choice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearofMembership = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EC_Relation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EC_Sub_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EC_Woreda = table.Column<int>(type: "int", nullable: true),
                    EC_House_Number = table.Column<int>(type: "int", nullable: true),
                    EC_Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Literatures",
                columns: table => new
                {
                    LiteratureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiteratureTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiteratureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiteratureFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WrittenMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WrittenYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literatures", x => x.LiteratureID);
                    table.ForeignKey(
                        name: "FK_Literatures_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Literatures_MemberID",
                table: "Literatures",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Literatures");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
