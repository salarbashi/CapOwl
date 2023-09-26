using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class edited_portfoliosymbols_table_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolioSymols_Symbols_SymbolId",
                table: "portfolioSymols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_portfolioSymols",
                table: "portfolioSymols");

            migrationBuilder.RenameTable(
                name: "portfolioSymols",
                newName: "PortfolioSymols");

            migrationBuilder.RenameIndex(
                name: "IX_portfolioSymols_SymbolId",
                table: "PortfolioSymols",
                newName: "IX_PortfolioSymols_SymbolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PortfolioSymols",
                table: "PortfolioSymols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioSymols_Symbols_SymbolId",
                table: "PortfolioSymols",
                column: "SymbolId",
                principalTable: "Symbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioSymols_Symbols_SymbolId",
                table: "PortfolioSymols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PortfolioSymols",
                table: "PortfolioSymols");

            migrationBuilder.RenameTable(
                name: "PortfolioSymols",
                newName: "portfolioSymols");

            migrationBuilder.RenameIndex(
                name: "IX_PortfolioSymols_SymbolId",
                table: "portfolioSymols",
                newName: "IX_portfolioSymols_SymbolId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_portfolioSymols",
                table: "portfolioSymols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolioSymols_Symbols_SymbolId",
                table: "portfolioSymols",
                column: "SymbolId",
                principalTable: "Symbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
