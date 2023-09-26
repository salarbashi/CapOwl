namespace API.Models.DTOs.WatchlistController
{
    public class GetWatchlistDataDto
    {
        public string Name { get; set; }

        public string Ticker { get; set; }

        public double DividendYield { get; set; }

        public double ProfitMargin { get; set; }

        public double PayoutRatio { get; set; }

        public double PeForward { get ; set; }
    }
}
