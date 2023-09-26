using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagerAPI.Migrations
{
    public partial class mi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Symbols",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Market",
                table: "Symbols",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Symbols");

            migrationBuilder.DropColumn(
                name: "Market",
                table: "Symbols");
        }
    }
}
