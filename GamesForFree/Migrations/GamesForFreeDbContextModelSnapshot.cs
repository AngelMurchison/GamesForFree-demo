﻿// <auto-generated />
using System;
using GamesForFree.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesForFree.Migrations
{
    [DbContext(typeof(GamesForFreeDbContext))]
    partial class GamesForFreeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("GamesForFree.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyTypeId");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CompanyTypeId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("GamesForFree.Models.CompanyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("CompanyType");

                    b.HasData(
                        new { Id = 1, Code = "DEV", Name = "Developer" },
                        new { Id = 2, Code = "PUB", Name = "Publisher" }
                    );
                });

            modelBuilder.Entity("GamesForFree.Models.CompanyVideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<int>("VideoGameId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("VideoGameId");

                    b.ToTable("CompanyVideoGame");
                });

            modelBuilder.Entity("GamesForFree.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<decimal>("GamePointsExchanged");

                    b.Property<int>("VideoGameId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VideoGameId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("GamesForFree.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<decimal>("GamePointBalance");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new { Id = 1, Email = "amurchison@email.com", FirstName = "Angel", GamePointBalance = 0m, LastName = "Murchison", Password = "password", UserName = "amurchison" }
                    );
                });

            modelBuilder.Entity("GamesForFree.Models.VideoGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AvailableForPurchase");

                    b.Property<string>("Description");

                    b.Property<decimal>("Price");

                    b.Property<DateTimeOffset>("ReleaseDate");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("VideoGame");
                });

            modelBuilder.Entity("GamesForFree.Models.Company", b =>
                {
                    b.HasOne("GamesForFree.Models.CompanyType", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamesForFree.Models.CompanyVideoGame", b =>
                {
                    b.HasOne("GamesForFree.Models.Company", "Company")
                        .WithMany("CompanyVideoGames")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamesForFree.Models.VideoGame", "VideoGame")
                        .WithMany("VideoGameCompanies")
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GamesForFree.Models.Transaction", b =>
                {
                    b.HasOne("GamesForFree.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GamesForFree.Models.VideoGame", "VideoGame")
                        .WithMany()
                        .HasForeignKey("VideoGameId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}