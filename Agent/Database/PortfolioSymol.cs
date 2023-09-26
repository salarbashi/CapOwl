using System.ComponentModel.DataAnnotations;

namespace Agent.Database
{
    public class PortfolioSymol
    {
        [Key]
        public int Id { get; set; }

        public Symbol Symbol { get; set; }

        public float Shares { get; set; }
    }
}
