using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent.DataProviders.Models
{
    public interface IFundamental:IFundamentalSummary
    {
        public double PriceToBook {  get; set; }

        public double ReturnOnEquity { get; set; }

        public double DebtToEquity { get; set; }

        public double PriceToSales { get; set; }

        public double Beta { get; set; }

        public double MarketCap { get; set; }
    }
}
