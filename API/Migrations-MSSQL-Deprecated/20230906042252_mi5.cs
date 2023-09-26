using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagerAPI.Migrations
{
    public partial class mi5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fundamentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolId = table.Column<int>(type: "int", nullable: false),
                    DividendYield = table.Column<double>(type: "float", nullable: false),
                    ProfitMargin = table.Column<double>(type: "float", nullable: false),
                    PayoutRatio = table.Column<double>(type: "float", nullable: false),
                    PeForward = table.Column<double>(type: "float", nullable: false),
                    PriceToBook = table.Column<double>(type: "float", nullable: false),
                    ReturnOnEquity = table.Column<double>(type: "float", nullable: false),
                    DebtToEquity = table.Column<double>(type: "float", nullable: false),
                    PriceToSales = table.Column<double>(type: "float", nullable: false),
                    Beta = table.Column<double>(type: "float", nullable: false),
                    MarketCap = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundamentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fundamentals_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fundamentals_SymbolId",
                table: "Fundamentals",
                column: "SymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundamentals");
        }
    }
}
