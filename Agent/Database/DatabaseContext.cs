
using Agent.Database;
using Microsoft.EntityFrameworkCore;

namespace Agent.Database
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Symbol> Symbols { get; set; }

        public DbSet<WatchListSymbol> WatchListSymbols { get; set; }

        public DbSet<Fundamental> Fundamentals { get; set; }

        public DbSet<PortfolioSymol> PortfolioSymols { get; set; }

        public DbSet<MarketData> MarketDatas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Helpers.Configuration.ConnectionString);
            var connectionString = "server=localhost;user=root;password=mohsal1532;database=FinancialManager";
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            optionsBuilder.UseMySql(connectionString, serverVersion, options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symbol>().HasIndex(e => e.Ticker).IsUnique();
        }
    }
}
