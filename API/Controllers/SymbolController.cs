using API.Database;
using API.Helpers.Cache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SymbolController : BaseController
    {
        private readonly ICacheHelper _cache;
        public SymbolController(DatabaseContext databaseContext, ICacheHelper cacheHelper) :
            base(databaseContext)
        {
            _cache = cacheHelper;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> SearchTickers(string searchChars)
        {
            var cachedObj = _cache.Get<IEnumerable<string>>(CacheKeys.TickerSearch + searchChars);

            if(cachedObj == null)
            {
                var symbols = await _databaseContext.Symbols.Where(s => EF.Functions.Like(s.Ticker,
                $"%{searchChars}%")).Take(10).Select(s => s.Ticker).ToListAsync();
                
                _cache.Set<IEnumerable<string>>(CacheKeys.TickerSearch + searchChars, symbols);
                cachedObj = symbols;
            }
            

            return cachedObj;
        }
    }
}
