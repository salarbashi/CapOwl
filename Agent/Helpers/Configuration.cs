

namespace Agent.Helpers
{
    /// <summary>
    /// gets data from appsettings.json
    /// </summary>
    public static class Configuration
    {
        public static string YahooFinanceBaseUrl { get { return "http://localhost:5247"; } }
        public static string YahooFinanceFundamentalSummary { get { return "fundamental/summary"; } }
        public static string YahooFinanceSymbolSummary { get { return "symbol/summary"; } }
        public static string YahooFinanceSymbolFull { get { return "symbol/full"; } }
        public static string ConnectionString { get { return "Data Source=MOHAMMADREZA;Initial Catalog=FinancialManager;Integrated Security=True;TrustServerCertificate=True"; } }
    }
}
