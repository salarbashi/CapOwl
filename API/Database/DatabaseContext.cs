using API.Database;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class DatabaseContext:DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Symbol> Symbols { get; set; }

        public DbSet<WatchListSymbol> WatchListSymbols { get; set; }

        public DbSet<Fundamental> Fundamentals { get; set; }

        public DbSet<PortfolioSymol> PortfolioSymols { get; set; }

        public DbSet<MarketData> MarketDatas { get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            var connectionString = _config.GetConnectionString("MySQL");
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            optionsBuilder.UseMySql(connectionString, serverVersion, options => options.EnableRetryOnFailure());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Symbol>().HasIndex(e => e.Ticker).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
