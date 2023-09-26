using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class mi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ticker = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exchange = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubSector = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fundamentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SymbolId = table.Column<int>(type: "int", nullable: false),
                    DividendYield = table.Column<double>(type: "double", nullable: false),
                    ProfitMargin = table.Column<double>(type: "double", nullable: false),
                    PayoutRatio = table.Column<double>(type: "double", nullable: false),
                    PeForward = table.Column<double>(type: "double", nullable: false),
                    PriceToBook = table.Column<double>(type: "double", nullable: false),
                    ReturnOnEquity = table.Column<double>(type: "double", nullable: false),
                    DebtToEquity = table.Column<double>(type: "double", nullable: false),
                    PriceToSales = table.Column<double>(type: "double", nullable: false),
                    Beta = table.Column<double>(type: "double", nullable: false),
                    MarketCap = table.Column<double>(type: "double", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WatchListSymbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SymbolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatchListSymbols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WatchListSymbols_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Fundamentals_SymbolId",
                table: "Fundamentals",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Symbols_Ticker",
                table: "Symbols",
                column: "Ticker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WatchListSymbols_SymbolId",
                table: "WatchListSymbols",
                column: "SymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fundamentals");

            migrationBuilder.DropTable(
                name: "WatchListSymbols");

            migrationBuilder.DropTable(
                name: "Symbols");
        }
    }
}
