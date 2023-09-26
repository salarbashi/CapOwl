using API.Database;
using API.Helpers;
using API.Models.DTOs.PortfolioController;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class PortfolioController : BaseController
    {
        private readonly DbHelper _dbHelper;
        public PortfolioController(DatabaseContext databaseContext, DbHelper dbHelper) :
            base(databaseContext)
        {
            this._dbHelper = dbHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPortfolioData()
        {
            var portfolioItems = await _databaseContext.PortfolioSymols.Include(m=> m.Symbol).
                Select(m=>m.Symbol.Ticker).ToListAsync();

            var fundamentals = new List<Fundamental>();
            var marketDatas = new List<MarketData>();

            try
            {
                fundamentals = await _dbHelper.GetSymbolsFundamentalAsync(portfolioItems);
                marketDatas = await _dbHelper.GetSymbolsMarketDataAsync(portfolioItems);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

            // Convert to DTO
            List<GetPortfolioDataDto> resultDto = fundamentals.OrderBy(f => f.Symbol.Ticker).
                Select(item => new GetPortfolioDataDto
                {
                    Name = item.Symbol.Name,
                    DividendYield = Math.Round(item.DividendYield, 4),
                    PayoutRatio = Math.Round(item.PayoutRatio, 4),
                    ProfitMargin = Math.Round(item.ProfitMargin, 4),
                    PeForward = Math.Round(item.PeForward, 2),
                    Ticker = item.Symbol.Ticker,
                    Close = marketDatas.Where(m=>m.Symbol.Ticker == item.Symbol.Ticker).Single().Close
                }).ToList();

            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddToPortfolio(string ticker)
        {
            //check if the symbol is already in symbol table
            var symbol = await GetSymbolByTickerAsync(ticker);

            try
            {
                //symbol exists in symbol table
                if (symbol != null)
                {
                    //**add symbol to portfolio table only**//

                    //check if symbol is in the portfolio table already
                    var portfolioSymbol = await GetPortfolioSymbolByTickerAsync(ticker);
                    if (portfolioSymbol != null)
                        return Ok("Symbol added to portfolio successfully!");

                    //if not add it to the portfolio table
                    await AddToPortfolioDbAsync(await GetSymbolByTickerAsync(ticker));
                    return Ok("Symbol added to portfolio successfully!");
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
        public async Task<IActionResult> RemoveFromPortfolio(string ticker)
        {
            //check if symbol is in the portfolio
            var portfolioSymbol = await GetPortfolioSymbolByTickerAsync(ticker);
            if (portfolioSymbol != null)
            {
                //remove symbol from portfolio
                await RemoveFromPortfolioDbAsync(portfolioSymbol);
                return Ok("Symbol removed from portfolio successfully!");
            }
            else
            {
                return BadRequest("Symbol is not in the portfolio!");
            }
        }

        private async Task RemoveFromPortfolioDbAsync(PortfolioSymol portfolioSymbol)
        {
            _databaseContext.PortfolioSymols.Remove(portfolioSymbol);
            await _databaseContext.SaveChangesAsync();
        }

        private async Task<PortfolioSymol> GetPortfolioSymbolByTickerAsync(string ticker)
        {
            var symbol = await GetSymbolByTickerAsync(ticker);
            var portfolioSymbol = await _databaseContext.PortfolioSymols.Where(m => m.Symbol == symbol).
                FirstOrDefaultAsync();

            return portfolioSymbol;
        }

        private async Task AddToPortfolioDbAsync(Symbol symbol)
        {
            await _databaseContext.PortfolioSymols.AddAsync(new PortfolioSymol { Symbol = symbol });
            await _databaseContext.SaveChangesAsync();
        }
    }
}
