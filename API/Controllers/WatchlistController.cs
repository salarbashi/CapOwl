
using API.Database;
using API.Models.DTOs.WatchlistController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using API.Helpers;

namespace API.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly DbHelper _dbHelper;
        public WatchlistController(DatabaseContext databaseContext, DbHelper dbHelper) :
            base(databaseContext)
        {
            this._dbHelper = dbHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetWatchlistData()
        {
            // Get watchlist items
            var watchlistItems = await _databaseContext.WatchListSymbols.Include(m => m.Symbol).
                Select(e => e.Symbol.Ticker).ToListAsync();
            
            List<Fundamental> fundamentals = new List<Fundamental>();

            try
            {
                fundamentals = await _dbHelper.GetSymbolsFundamentalAsync(watchlistItems);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            // Convert to DTO
            List<GetWatchlistDataDto> resultDto = fundamentals.OrderBy(f=>f.Symbol.Ticker).
                Select(item => new GetWatchlistDataDto
            {
                Name = item.Symbol.Name,
                DividendYield = Math.Round(item.DividendYield, 4),
                PayoutRatio = Math.Round(item.PayoutRatio, 4),
                ProfitMargin = Math.Round(item.ProfitMargin, 4),
                PeForward = Math.Round(item.PeForward, 2),
                Ticker = item.Symbol.Ticker
            }).ToList();

            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchList(string ticker)
        {
            //check if the symbol is already in symbol table
            var symbol = await GetSymbolByTickerAsync(ticker);

            try
            {
                //symbol exists in symbol table
                if (symbol != null)
                {
                    //**add symbol to wathclist table only**//

                    //check if symbol is in the watchlist table already
                    var watchListSymbol = await GetWatclistSymbolByTickerAsync(ticker);
                    if (watchListSymbol != null)
                        return Ok("Symbol added to wathclist successfully!");

                    //if not add it to the watchlist table
                    await AddToWathclistDbAsync(await GetSymbolByTickerAsync(ticker));
                    return Ok("Symbol added to wathclist successfully!");
                }

                //symbol does not exist in symbol table
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest("There was an error in adding the symbol");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromWatchList(string ticker)
        {
            //check if symbol is in the wathclist
            var watchListSymbol = await GetWatclistSymbolByTickerAsync(ticker);
            if (watchListSymbol != null)
            {
                //remove symbol from watchlist
                await RemoveFromWachListDbAsync(watchListSymbol);
                return Ok("Symbol removed from watchlist successfully!");
            }
            else
            {
                return BadRequest("Symbol is not in the watchlist!");
            }
        }

        private async Task AddToWathclistDbAsync(Symbol symbol)
        {
            await _databaseContext.WatchListSymbols.AddAsync(new WatchListSymbol { Symbol = symbol });
            await _databaseContext.SaveChangesAsync();
        }

        private async Task RemoveFromWachListDbAsync(WatchListSymbol watchListSymbol)
        {
            _databaseContext.WatchListSymbols.Remove(watchListSymbol);
            await _databaseContext.SaveChangesAsync();
        }

        private async Task<WatchListSymbol> GetWatclistSymbolByTickerAsync(string ticker)
        {
            var symbol = await GetSymbolByTickerAsync(ticker);
            var watchListSymbol = await _databaseContext.WatchListSymbols.Where(m => m.Symbol == symbol).
                FirstOrDefaultAsync();

            return watchListSymbol;
        }

    }
}
