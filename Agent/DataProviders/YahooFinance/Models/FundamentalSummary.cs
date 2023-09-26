using Agent.DataProviders.Models;
using System.Text.Json.Serialization;

namespace Agent.DataProviders.YahooFinance.Models
{
    public class FundamentalSummary : Symbol, IFundamentalSummary
    {
        public double DividendYield { get; set; }

        public double ProfitMargin { get; set; }

        public double PayoutRatio { get; set; }

        public double PeForward { get; set; }
    }
}
