namespace Agent.DataProviders.Models
{
    public interface IFundamentalSummary : ISymbol
    {
        public double DividendYield { get; set; }

        public double ProfitMargin { get; set; }

        public double PayoutRatio { get; set; }

        public double PeForward { get; set; }
    }
}
