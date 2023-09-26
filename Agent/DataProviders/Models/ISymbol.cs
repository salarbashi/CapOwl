namespace Agent.DataProviders.Models
{
    public interface ISymbol
    {
        public string Name { get; set; }

        public string Ticker { get; set; }

        public string Type { get; set; }

        public string? Exchange { get; set; }

        public string? Country { get; set; }
    }
}
