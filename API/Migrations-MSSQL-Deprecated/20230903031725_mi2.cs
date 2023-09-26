using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagerAPI.Migrations
{
    public partial class mi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Symbols",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Symbols");
        }
    }
}
