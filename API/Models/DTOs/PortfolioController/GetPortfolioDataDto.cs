namespace API.Models.DTOs.PortfolioController
{
    public class GetPortfolioDataDto
    {
        public string Name { get; set; }

        public string Ticker { get; set; }

        public double DividendYield { get; set; }

        public double ProfitMargin { get; set; }

        public double PayoutRatio { get; set; }

        public double PeForward { get; set; }

        public float Close { get; set; }
    }
}
