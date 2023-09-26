using System.ComponentModel.DataAnnotations;

namespace Agent.Database
{
    public class WatchListSymbol
    {
        [Key]
        public int Id { get; set; }

        public Symbol Symbol { get; set; }
    }
}
