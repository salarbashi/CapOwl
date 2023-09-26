using Agent.DataProviders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataProviders.YahooFinance.Models
{
    public class SymbolFull : ISymbolFull
    {
        public double PriceToBook { get ; set ; }
        public double ReturnOnEquity { get ; set ; }
        public double DebtToEquity { get ; set ; }
        public double PriceToSales { get ; set ; }
        public double Beta { get ; set ; }
        public double MarketCap { get ; set ; }
        public double DividendYield { get ; set ; }
        public double ProfitMargin { get ; set ; }
        public double PayoutRatio { get ; set ; }
        public double PeForward { get ; set ; }
        public string Name { get ; set ; }
        public string Ticker { get ; set ; }
        public string Type { get ; set ; }
        public string? Exchange { get ; set ; }
        public string? Country { get ; set ; }
        public float Close { get ; set ; }
        public float Open { get ; set ; }
        public float High { get ; set ; }
        public float Low { get ; set ; }
        public float Volume { get ; set ; }
    }
}
