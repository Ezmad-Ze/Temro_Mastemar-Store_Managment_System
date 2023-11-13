using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class AddUniqueIDToMember1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Unique_id",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql(@"
                CREATE TRIGGER UpdateUniqueId
                ON Member
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    UPDATE Member
                    SET Unique_id = SUBSTRING(FullName, 1, 2) +
                                    CASE 
                                        WHEN Father_name IS NOT NULL AND Father_name <> '' THEN SUBSTRING(Father_name, 1, 2)
                                        ELSE ''
                                    END +
                                    SUBSTRING(GrandFather_Name, 1, 2) +
                                    '-' + CONVERT(VARCHAR(4), YEAR(YearofMembership))
                    WHERE MemberID IN (SELECT MemberID FROM inserted)
                END
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER UpdateUniqueId");

            migrationBuilder.DropColumn(
                name: "Unique_id",
                table: "Members");
        }
    }
}
