using Agent.DataProviders.Models;

namespace Agent.DataProviders
{
    public interface IFinanceDataProvider
    {
        
        public Task<ISymbol> GetSymbolSummaryAsync(string ticker);
        public Task<ISymbolFull> GetSymbolFullAsync(string ticker);
        public Task<IFundamental> GetFundamentalAsync(string ticker);
    }
}
