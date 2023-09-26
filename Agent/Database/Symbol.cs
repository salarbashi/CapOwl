using System.ComponentModel.DataAnnotations;

namespace Agent.Database
{
    public class Symbol
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ticker { get; set; }

        public string Name { get; set; }

        public string? Type { get; set; }

        public string? Exchange { get; set; }

        public string? Country { get; set; }

        public string? Sector { get; set; }

        public string? SubSector { get; set; }
    }
}
