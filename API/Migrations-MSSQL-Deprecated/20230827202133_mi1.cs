using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialManagerAPI.Migrations
{
    public partial class mi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListSymbol_Symbol_SymbolId",
                table: "WatchListSymbol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchListSymbol",
                table: "WatchListSymbol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Symbol",
                table: "Symbol");

            migrationBuilder.RenameTable(
                name: "WatchListSymbol",
                newName: "WatchListSymbols");

            migrationBuilder.RenameTable(
                name: "Symbol",
                newName: "Symbols");

            migrationBuilder.RenameIndex(
                name: "IX_WatchListSymbol_SymbolId",
                table: "WatchListSymbols",
                newName: "IX_WatchListSymbols_SymbolId");

            migrationBuilder.RenameIndex(
                name: "IX_Symbol_Ticker",
                table: "Symbols",
                newName: "IX_Symbols_Ticker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchListSymbols",
                table: "WatchListSymbols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListSymbols_Symbols_SymbolId",
                table: "WatchListSymbols",
                column: "SymbolId",
                principalTable: "Symbols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WatchListSymbols_Symbols_SymbolId",
                table: "WatchListSymbols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WatchListSymbols",
                table: "WatchListSymbols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Symbols",
                table: "Symbols");

            migrationBuilder.RenameTable(
                name: "WatchListSymbols",
                newName: "WatchListSymbol");

            migrationBuilder.RenameTable(
                name: "Symbols",
                newName: "Symbol");

            migrationBuilder.RenameIndex(
                name: "IX_WatchListSymbols_SymbolId",
                table: "WatchListSymbol",
                newName: "IX_WatchListSymbol_SymbolId");

            migrationBuilder.RenameIndex(
                name: "IX_Symbols_Ticker",
                table: "Symbol",
                newName: "IX_Symbol_Ticker");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WatchListSymbol",
                table: "WatchListSymbol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Symbol",
                table: "Symbol",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WatchListSymbol_Symbol_SymbolId",
                table: "WatchListSymbol",
                column: "SymbolId",
                principalTable: "Symbol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
