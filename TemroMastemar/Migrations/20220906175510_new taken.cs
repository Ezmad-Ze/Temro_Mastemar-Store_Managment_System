using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemroMastemar.Migrations
{
    public partial class newtaken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "TakenLiteratures",
                columns: table => new
                {
                    TakenLiteratureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TL_Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TL_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TL_LiteratureType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Giver = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TL_Time = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenLiteratures", x => x.TakenLiteratureID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TakenLiteratures");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
