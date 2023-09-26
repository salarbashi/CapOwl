using API.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BaseController : Controller
    {
        protected readonly DatabaseContext _databaseContext;

        public BaseController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        protected async Task<Symbol> GetSymbolByTickerAsync(string ticker)
        {
            var result = await _databaseContext.Symbols.Where(m => m.Ticker == ticker).FirstOrDefaultAsync();
            return result;
        }
    }
}
