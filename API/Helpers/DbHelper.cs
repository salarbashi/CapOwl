using API.Database;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public class DbHelper
    {
        private readonly DatabaseContext _dbContext;
        public DbHelper(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Fundamental>> GetSymbolsFundamentalAsync(List<string> tickers)
        {
            List<Fundamental> result = new();

            foreach (string ticker in tickers)
            {
                result.Add(await GetFundamentalSummary(ticker));
            }

            return result;
        }

        public async Task<List<MarketData>> GetSymbolsMarketDataAsync(List<string> tickers)
        {
            List<MarketData> result = new();

            foreach (string ticker in tickers)
            {
                result.Add(await GetMarketData(ticker));
            }

            return result;
        }

        private async Task<Fundamental> GetFundamentalSummary(string ticker)
        {
            var dbFundamental = await _dbContext.Fundamentals.Include(e => e.Symbol).
                Where(i => i.Symbol.Ticker == ticker).SingleOrDefaultAsync();

            if (dbFundamental == null)
            {
                throw new Exception("Fundamental not found!");
            }

            return dbFundamental;
        }

        private async Task<MarketData> GetMarketData(string ticker)
        {
            var dbMarketData = await _dbContext.MarketDatas.Include(e => e.Symbol).
                Where(i => i.Symbol.Ticker == ticker).SingleOrDefaultAsync();

            if (dbMarketData == null)
            {
                throw new Exception("Market data not found!");
            }

            return dbMarketData;
        }
    }
}
