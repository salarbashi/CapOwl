using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    /// <summary>
    /// gets data from appsettings.json
    /// </summary>
    public class Configuration
    {
        private readonly IConfiguration _configuration;

        public string YahooFinanceBaseUrl { get { return _configuration["EndPoints:YahooFinance:BaseUrl"]; } }
        public string YahooFinanceFundamentalSummary { get { return _configuration["EndPoints:YahooFinance:FundamentalSummary"]; } }
        public string YahooFinanceSymbolSummary { get { return _configuration["EndPoints:YahooFinance:SymbolSummary"]; } }

        public Configuration(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
