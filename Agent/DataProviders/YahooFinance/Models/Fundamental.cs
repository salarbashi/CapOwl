using Agent.DataProviders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataProviders.YahooFinance.Models
{
    public class Fundamental : FundamentalSummary, IFundamental
    {
        public double PriceToBook { get; set; }

        public double ReturnOnEquity { get; set; }

        public double DebtToEquity { get; set; }

        public double PriceToSales { get; set; }

        public double Beta { get; set; }

        public double MarketCap { get; set; }
    }
}
