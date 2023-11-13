using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class UniqueIDFatherAndGrandFatherName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Unique_id",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.Sql(@"
                CREATE TRIGGER UpdateUniqueId
                ON Members
                AFTER INSERT, UPDATE
                AS
                BEGIN
                    UPDATE Members
                    SET Unique_id = SUBSTRING(Name, 1, 2) +
                                    CASE 
                                        WHEN GrandFather_Name IS NOT NULL AND GrandFather_Name <> '' THEN SUBSTRING(GrandFather_Name, 1, 2)
                                        ELSE ''
                                    END +
                                    SUBSTRING(Father_Name, 1, 2) +
                                    '-' + CONVERT(VARCHAR(4), YEAR(YearofMembership))
                    WHERE MemberID IN (SELECT MemberID FROM inserted)
                END
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER UpdateUniqueId");

            migrationBuilder.AlterColumn<string>(
                name: "Unique_id",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
