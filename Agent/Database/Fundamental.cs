using Agent.Database;
using System.ComponentModel.DataAnnotations;

namespace Agent.Database
{
    public class Fundamental
    {
        [Key]
        public int Id { get; set; }

        public Symbol Symbol { get; set; }

        public double DividendYield { get; set; }

        public double ProfitMargin { get; set; }

        public double PayoutRatio { get; set; }

        public double PeForward { get; set; }

        public double PriceToBook { get; set; }

        public double ReturnOnEquity { get; set; }

        public double DebtToEquity { get; set; }

        public double PriceToSales { get; set; }

        public double Beta { get; set; }

        public double MarketCap { get; set; }
    }
}
