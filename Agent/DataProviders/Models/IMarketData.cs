namespace Agent.DataProviders.Models
{
    public interface IMarketData
    {
        public float Close { get; set; }

        public float Open { get; set; }

        public float High { get; set; }

        public float Low { get; set; }

        public float Volume { get; set; }
    }
}