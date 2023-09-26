using Agent.DataProviders.Models;
using Agent.DataProviders.YahooFinance.Models;
using Agent.Helpers;

namespace Agent.DataProviders.YahooFinance
{
    public class YahooProvider : IFinanceDataProvider
    {
        private APIClient _client;

        public YahooProvider()
        {
            _client = new APIClient(Configuration.YahooFinanceBaseUrl);
        }


        public async Task<ISymbol> GetSymbolSummaryAsync(string ticker)
        {
            var response = await _client.GetAsync<Symbol>(Configuration.YahooFinanceSymbolSummary,
                new Dictionary<string, string> { { "ticker", ticker } });

            return response;
        }

        public async Task<IFundamental> GetFundamentalAsync(string ticker)
        {
            var response = await _client.GetAsync<Fundamental>(Configuration.YahooFinanceFundamentalSummary,
                new Dictionary<string, string> { { "ticker", ticker } });

            return response;
        }

        public async Task<ISymbolFull> GetSymbolFullAsync(string ticker)
        {
            var response = await _client.GetAsync<SymbolFull>(Configuration.YahooFinanceSymbolFull,
                new Dictionary<string, string> { { "ticker", ticker } });

            return response;
        }
    }
}
