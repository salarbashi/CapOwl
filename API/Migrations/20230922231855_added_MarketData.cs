using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class added_MarketData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Close = table.Column<float>(type: "float", nullable: false),
                    Open = table.Column<float>(type: "float", nullable: false),
                    High = table.Column<float>(type: "float", nullable: false),
                    Low = table.Column<float>(type: "float", nullable: false),
                    Volume = table.Column<float>(type: "float", nullable: false),
                    SymbolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketDatas_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "portfolioSymols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SymbolId = table.Column<int>(type: "int", nullable: false),
                    Shares = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioSymols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioSymols_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MarketDatas_SymbolId",
                table: "MarketDatas",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioSymols_SymbolId",
                table: "portfolioSymols",
                column: "SymbolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketDatas");

            migrationBuilder.DropTable(
                name: "portfolioSymols");
        }
    }
}
