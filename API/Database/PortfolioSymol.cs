using System.ComponentModel.DataAnnotations;

namespace API.Database
{
    public class PortfolioSymol
    {
        [Key]
        public int Id { get; set; }

        public Symbol Symbol { get; set; }

        //number of shares owner owns
        public float Shares { get; set; }
    }
}
