﻿// <auto-generated />
using FinancialManagerAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinancialManagerAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230903031803_mi3")]
    partial class mi3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinancialManagerAPI.Entities.Symbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubSector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Ticker")
                        .IsUnique();

                    b.ToTable("Symbols");
                });

            modelBuilder.Entity("FinancialManagerAPI.Entities.WatchListSymbol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("SymbolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SymbolId");

                    b.ToTable("WatchListSymbols");
                });

            modelBuilder.Entity("FinancialManagerAPI.Entities.WatchListSymbol", b =>
                {
                    b.HasOne("FinancialManagerAPI.Entities.Symbol", "Symbol")
                        .WithMany("WatchListSymbols")
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Symbol");
                });

            modelBuilder.Entity("FinancialManagerAPI.Entities.Symbol", b =>
                {
                    b.Navigation("WatchListSymbols");
                });
#pragma warning restore 612, 618
        }
    }
}
