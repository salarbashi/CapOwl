using Agent.DataProviders.Models;
using System.Text.Json.Serialization;

namespace Agent.DataProviders.YahooFinance.Models
{
    public class Symbol:ISymbol
    {
        public string Name { get; set; }

        public string Ticker { get; set; }

        public string Type { get; set; }

        public string? Exchange { get; set; }

        public string? Country { get; set; }
    }
}
