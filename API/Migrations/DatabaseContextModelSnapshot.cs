﻿// <auto-generated />
using API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FinancialManagerAPI.Database.Fundamental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Beta")
                        .HasColumnType("double");

                    b.Property<double>("DebtToEquity")
                        .HasColumnType("double");

                    b.Property<double>("DividendYield")
                        .HasColumnType("double");

                    b.Property<double>("MarketCap")
                        .HasColumnType("double");

                    b.Property<double>("PayoutRatio")
                        .HasColumnType("double");

                    b.Property<double>("PeForward")
                        .HasColumnType("double");

                    b.Property<double>("PriceToBook")
                        .HasColumnType("double");

                    b.Property<double>("PriceToSales")
                        .HasColumnType("double");

                    b.Property<double>("ProfitMargin")
                        .HasColumnType("double");

                    b.Property<double>("ReturnOnEquity")
                        .HasColumnType("double");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("Fundamentals");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.MarketData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Close")
                        .HasColumnType("float");

                    b.Property<float>("High")
                        .HasColumnType("float");

                    b.Property<float>("Low")
                        .HasColumnType("float");

                    b.Property<float>("Open")
                        .HasColumnType("float");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.Property<float>("Volume")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("MarketDatas");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.PortfolioSymol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Shares")
                        .HasColumnType("float");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("PortfolioSymols");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.Symbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Exchange")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sector")
                        .HasColumnType("longtext");

                    b.Property<string>("SubSector")
                        .HasColumnType("longtext");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Ticker")
                        .IsUnique();

                    b.ToTable("Symbols");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.WatchListSymbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("WatchListSymbols");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.Fundamental", b =>
                {
                    b.HasOne("FinancialManagerAPI.Database.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.MarketData", b =>
                {
                    b.HasOne("FinancialManagerAPI.Database.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.PortfolioSymol", b =>
                {
                    b.HasOne("FinancialManagerAPI.Database.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("FinancialManagerAPI.Database.WatchListSymbol", b =>
                {
                    b.HasOne("FinancialManagerAPI.Database.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });
#pragma warning restore 612, 618
        }
    }
}
